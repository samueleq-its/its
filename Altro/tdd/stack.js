class Stack {
	size;
	top;

	constructor() {
		this.size = 0;
		this.top = null;
	}

	push(value) {
		this.size++;
		let newElem = new StackElem(value, this.top);
		this.top = newElem;
		return this.size;
	}

	pop() {
		if (this.top == null) {
			throw new StackEmptyError();
		}
		this.size--;
		let value = this.top.value;
		this.top = this.top.next;
		return value;
	}

	peek() {
		if (this.top == null) {
			throw new StackEmptyError();
		}
		return this.top.value;
	}

}

class StackElem {
	constructor(value, next = null) {
		this.value = value;
		this.next = next;
	}
}

class StackEmptyError extends Error {
	constructor() {
		super("stack is empty");
	}
}


module.exports = {
	Stack,
	StackEmptyError
}