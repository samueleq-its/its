<?php

class Fornitore
{
	private int $idFornitore;
	private string $ragioneSociale;
	private string $citta;
	private string $email;

	public function __construct(int $idFornitore, string $ragioneSociale, string $citta, string $email)
	{
		$this->idFornitore = $idFornitore;
		$this->ragioneSociale = $ragioneSociale;
		$this->citta = $citta;
		$this->email = $email;
	}

	public function __get($name)
	{
		return $this->$name;
	}

	public function __set($name, $value)
	{
		$this->$name = $value;
	}

	public function __tostring()
	{
		return $this->ragioneSociale;
	}
}
