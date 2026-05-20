<?php
class Categoria
{
	private int $idCategoria;
	private String $nome;

	public function __construct(int $idCategoria, String $nome)
	{
		$this->idCategoria = $idCategoria;
		$this->nome = $nome;
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
		return $this->nome;
	}
}
