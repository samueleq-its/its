const { Stack, StackEmptyError } = require("../stack")

describe("Stack", () => {

	let stack;

	beforeEach(() => {
		stack = new Stack();
	});

	it("created empty", () => {
		expect(stack.size).toEqual(0);
		expect(() => stack.pop()).toThrow(StackEmptyError);
		expect(() => stack.peek()).toThrow(StackEmptyError);
	});

	it("single push", () => {
		stack.push("first");
		expect(stack.size).toEqual(1);
		expect(stack.peek()).toEqual("first");
	});

	it("full", () => {
		stack.push("first");
		expect(stack.push("second")).toEqual(2);
		expect(stack.size).toEqual(2);
		expect(stack.peek()).toEqual("second");
		expect(stack.pop()).toEqual("second");

		expect(stack.size).toEqual(1);
		expect(stack.peek()).toEqual("first");
		expect(stack.pop()).toEqual("first");

		expect(stack.size).toEqual(0);
		expect(() => stack.peek()).toThrow(StackEmptyError);
		expect(() => stack.pop()).toThrow(StackEmptyError);
	});
})