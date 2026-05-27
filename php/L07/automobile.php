<?php
class Automobile
{
	// this.$marca = $marca è implicito
	public function __construct(
		private $marca,
		private $modello,
		private $anno=2026
	) {}


	public function __get($nome) {
		return $this->$nome;
	}

	public function __set($nome, $valore) {
		$this->$nome = $valore;
	}
}
