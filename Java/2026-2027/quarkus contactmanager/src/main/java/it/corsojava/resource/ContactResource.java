package it.corsojava.resource;

import java.util.List;

import jakarta.inject.Inject;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;

import it.corsojava.entity.Contact;
import it.corsojava.service.ContactService;

@Path("/api/contacts")
@Produces(MediaType.APPLICATION_JSON)
@Consumes(MediaType.APPLICATION_JSON)
public class ContactResource {

	@Inject
	ContactService service;

	@GET
	public List<Contact> findAll() {
		return service.findAll();
	}

	@GET
	@Path("/{id}")
	public Response findById(@PathParam("id") Long id) {

		Contact contact = service.findById(id);

		if (contact == null) {
			return Response.status(404).build();
		}

		return Response.ok(contact).build();
	}

	@POST
	public Response create(Contact contact) {

		Contact created = service.create(contact);

		return Response.status(201)
				.entity(created)
				.build();
	}

	@PUT
	@Path("/{id}")
	public Response update(
			@PathParam("id") Long id,
			Contact data) {

		Contact updated = service.update(id, data);

		if (updated == null) {
			return Response.status(404).build();
		}

		return Response.ok(updated).build();
	}

	@DELETE
	@Path("/{id}")
	public Response delete(@PathParam("id") Long id) {

		boolean deleted = service.delete(id);

		if (!deleted) {
			return Response.status(404).build();
		}

		return Response.noContent().build();
	}
}