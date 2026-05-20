<?php

include_once "../model/Categoria.php";
include_once "../model/Fornitore.php";

class Prodotto
{
	private int $idProdotto;
	private String $nome;
	private float $prezzoUnitario;
	private int $quantitaStock;
	private Categoria $categoria;
	private Fornitore $fornitore;

	public function __construct(int $idProdotto, String $nome, float $prezzoUnitario, int $quantitaStock, Categoria $categoria, Fornitore $fornitore)
	{
		$this->idProdotto = $idProdotto;
		$this->nome = $nome;
		$this->prezzoUnitario = $prezzoUnitario;
		$this->quantitaStock = $quantitaStock;
		$this->categoria = $categoria;
		$this->fornitore = $fornitore;
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
		return $this->nome . " - " . $this->categoria->nome . " - " . $this->fornitore-> ragioneSociale;
	}
}
