<?php
namespace APP\model;

class Motocicletta
{
	public function __construct(
		private $id,
		private $marca,
		private $modello,
		private $cilindrata,
		private $prezzo
	) {}

	public function __get($name)
	{
		return $this->$name;
	}

	public function __set($name, $value)
	{
		$this->$name = $value;
	}

	public function __toString()
	{
		return "Automobile: $this->marca $this->modello, Cilindrata: $this->cilindrata cc, Prezzo: €$this->prezzo";
	}
}
