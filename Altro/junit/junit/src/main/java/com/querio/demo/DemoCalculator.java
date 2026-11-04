package com.querio.demo;

import java.security.InvalidParameterException;

public class DemoCalculator {

	public static int calculate(int a, String operator, int b) throws Exception {
		if (operator == null) {
			throw new Exception();
		}
		Operation operation = Operation.fromOperator(operator);

		return operation.calc(a, b);
	}

	public enum Operation {
		SUM {
			@Override
			public int calc(int a, int b) {
				return a + b;
			}
		},
		SUBTRACTION {

			@Override
			public int calc(int a, int b) {
				return a - b;
			}
		},
		MULTIPLICATION {
			@Override
			public int calc(int a, int b) {
				return a * b;
			}
		},
		DIVISION {
			@Override
			public int calc(int a, int b) {
				return a / b;
			}
		};

		public int calc(int a, int b) {
			return 0;
		}

		public static Operation fromOperator(String operator) {
			switch (operator) {
				case "+":
					return Operation.SUM;
				case "-":
					return Operation.SUBTRACTION;
				case "*":
					return Operation.MULTIPLICATION;
				case "/":
					return Operation.DIVISION;

				default:
					throw new InvalidParameterException("operator not recognized");
			}
		}

	}
}
