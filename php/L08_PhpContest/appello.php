<?php

class Studente
{
	function __construct(
		private $id,
		private $nome,
		private $cognome
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
		return 'ID: ' . $this->id . ' - Nome: ' . $this->nome . ' - Cognome: ' . $this->cognome;
	}
}

$studenti = file('./studenti.csv');

$oggetti_studenti = [];

foreach ($studenti as $studente) {
	$dati = explode(',', $studente);
	$oggetti_studenti[] = new Studente($dati[0], $dati[1], $dati[2]);
}

$indice = array_rand($oggetti_studenti);
echo "And the winner is: " . $oggetti_studenti[$indice];
echo "esercizio: " . random_int(1,28);
