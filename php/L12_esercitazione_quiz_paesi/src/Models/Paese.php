<?php

namespace App\Models;

class Paese
{
	public function __construct(
		private string $name,
		private string $capital,
		private int $population,
		private string $code
	) {}

	public function __get($property)
	{
		return $this->$property;
	}

	public function __set($property, $value)
	{
		$this->$property = $value;
	}
}
