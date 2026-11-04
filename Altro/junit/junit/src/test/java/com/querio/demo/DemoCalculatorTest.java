package com.querio.demo;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.Test;

public class DemoCalculatorTest {

	@Test
	void testCalculate() {
		// assertEquals(2, DemoCalculator.calculate(1, "+", 1));
		assertThrows(Exception.class, () -> {
			DemoCalculator.calculate(1, null, 1);
		});
	}

}
