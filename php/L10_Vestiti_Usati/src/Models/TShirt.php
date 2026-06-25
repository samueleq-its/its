<?php

namespace App\Models;

use App\Models\Maglia;

class TShirt extends Maglia
{
	public function __construct(
		$id,
		$nome,
		$prezzo,
		$categoria
	) {
		parent::__construct($id, $nome, $prezzo, $categoria);
	}

	public function __get($property)
	{
		return parent::__get($property);
	}

	public function __set($property, $value)
	{
		parent::__set($property, $value);
	}
}