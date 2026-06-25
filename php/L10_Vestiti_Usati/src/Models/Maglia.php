<?php

namespace App\Models;

class Maglia
{
	public function __construct(
		private $id,
		private $nome,
		private $prezzo,
		private $categoria
	) {}

	public function __get($property)
	{
		return $this->$property;
	}

	public function __set($property, $value)
	{
		$this->$property = $value;
	}

	public function __toString()
	{
		return "Maglia: $this->nome, Prezzo: $this->prezzo, Categoria: $this->categoria";
	}
}
