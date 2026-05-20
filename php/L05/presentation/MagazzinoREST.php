<?php

include_once '../service/Magazzino.php';

class MagazzinoRest
{
	private Magazzino $magazzino;

	public function __construct() {
		$this->magazzino = new Magazzino();
	}

	public function getFornitori(): string {
		return json_encode($this->magazzino->getFornitori());
	}

	public function getFornitoreById(int $id): string {
		return json_encode($this->magazzino->getFornitoreById($id));
	}
}