import { DynamoDBClient } from "@aws-sdk/client-dynamodb";
import { DynamoDBDocumentClient, UpdateCommand, GetCommand, PutCommand } from "@aws-sdk/lib-dynamodb";
import { z } from "zod"

/**
 * @typedef {Object} Film
 * @property {string} title
 * @property {string} director
 * @property {[string]} actors
 * @property {[string]} genres
 * @property {number} year
 */

/**
 * @typedef {Object} Response
 * @property {number} statusCode
 * @property {Object} headers
 * @property {string} body
 */

const MINISTACK_ENDPOINT = process.env.AWS_ENDPOINT_URL;
const TABLE_FILMS = "Films";
const TABLE_COUNTERS = "Counters";

/**
 * @param {Object} event
 * @returns 
 */
export const handler = async (event) => {
	const method = event.httpMethod ?? event.requestContext.http.method;

	const _id = Number(event.queryStringParameters?.id);
	const id = Number.isSafeInteger(_id) && _id > 0 ? _id : NaN;

	const body = event.body ? JSON.parse(event.body) : null;

	switch (method) {
		case "GET":
			if (!id) {
				return formatResponse(400, { error: "id is required and must be a positive integer" })
			}
			return service.find(id);

		case "POST":
			if (!body) {
				return formatResponse(400, { error: "missing body" })
			}
			return service.add(body);

		case "PUT":

			return;
		default:
			return formatResponse(405, { message: `method ${method} not allowed` })
	}
};

/**
 * @param {number} status 
 * @param {*} body
 * @returns {Response}
 */
function formatResponse(status, body) {
	return {
		statusCode: status,
		headers: { "Content-Type": "application/json" },
		body: JSON.stringify(body),
	}
}

class Service {

	filmSchema = z.object({
		title: z.string(),
		director: z.string(),
		actors: z.array(z.string()),
		genres: z.array(z.string()),
		year: z.number().int().positive()
	}).strict()

	/**
	 * @param {Repo} repo 
	 */
	constructor(repo) {
		this.repo = repo;
	}

	/**
	 * @param {number} id 
	 * @returns {Response}
	 */
	async find(id) {
		try {
			let film = await this.repo.find(id);
			return formatResponse(200, film);
		} catch (e) {
			return formatResponse(404, { error: e.message });
		}
	}

	/**
	 * @param {Film} film
	 * @returns {Response}
	 */
	async add(rawFilm) {
		// validation
		let validated = this.filmSchema.safeParse(rawFilm);
		if (validated.error) {
			return formatResponse(400, z.flattenError(validated.error));
		}

		let newId = await this.repo.add(validated.data);

		if (newId === 0) {
			return formatResponse(500, "failed processing the request");
		}
		return formatResponse(201, { id: newId });
	}

	/**
	 * @param {number} id 
	 * @param {Film} film 
	 * @returns {Film}
	 */
	update(id, film) {

	}
}

class Repo {
	constructor() {
		const config = { region: "us-east-1" };

		if (MINISTACK_ENDPOINT) {
			config.endpoint = MINISTACK_ENDPOINT;
		}

		this.db = new DynamoDBClient(config);
		this.dbDoc = DynamoDBDocumentClient.from(this.db);
	}

	/**
	 * @param {number} id 
	 * @returns {Promise<Film>}
	 * @throws {NotFoundError}
	 */
	async find(id) {
		let result = await this.dbDoc.send(new GetCommand({
			TableName: TABLE_FILMS,
			Key: { id: id }
		}))
		if (!result.Item) {
			throw new NotFoundError("Film not found");
		}
		return result.Item;
	}

	/**
	 * @param {Film} film 
	 * @returns {Promise<number>} film's id, 0 for error
	 */
	async add(film) {

		const response = await this.db.send(new UpdateCommand({
			TableName: TABLE_COUNTERS,
			Key: { name: "films" },
			UpdateExpression: "ADD current_value :inc",
			ExpressionAttributeValues: { ":inc": 1 },
			ReturnValues: "UPDATED_NEW"
		}));

		const id = response.Attributes.current_value;

		film.id = id;

		try {
			let result = await this.dbDoc.send(new PutCommand({
				TableName: TABLE_FILMS,
				Item: film
			}));
			if (result.$metadata.httpStatusCode == 200) {
				return id;
			}
		} catch (error) {
			return 0;
		}
	}

	/**
	 * @param {number} id 
	 * @param {Film} film 
	 * @returns {Film}
	 * @throws {NotFoundError}
	 */
	update(id, film) {

	}
}

class ValidationError extends Error {
	/**
	 * @param {string} message 
	 */
	constructor(message) {
		super();
		this.message = message;
		this.name = "ValidationError";
	}
}

class NotFoundError extends Error {
	/**
	 * @param {string} message 
	 */
	constructor(message) {
		super();
		this.message = message;
		this.name = "NotFoundError";
	}
}

const repo = new Repo();
const service = new Service(repo);
