package com.querio.demo;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

public class DemoCalculatorTest {

	@Test
	void testCalculateSum() {
		assertEquals(0, DemoCalculator.calculate(0, "+", 0));
		assertEquals(2, DemoCalculator.calculate(1, "+", 1));
		assertEquals(0, DemoCalculator.calculate(-1, "+", 1));
		assertEquals(12, DemoCalculator.calculate(5, "+", 7));
		assertEquals(10, DemoCalculator.calculate(0, "+", 10));
	}

}
