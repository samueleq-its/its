<?php

class Prodotto
{
	public function __construct(
		private $nome,
		private $categoria,
		private $prezzo,
		private $giacenza
	) {}

	public function __get($property)
	{
		return $this->$property;
	}

	public function __set($property, $value)
	{
		$this->$property = $value;
	}

	public function __toString(){
		return "Nome: $this->nome, Categoria: $this->categoria, Prezzo: $this->prezzo, Giacenza: $this->giacenza";
	}

}
