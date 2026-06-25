<?php

namespace App\Repos;

use App\Models\TShirt;

interface AbbigliamentoDAO
{
	public function getAll();
	public function getById($id);
	public function save($item);
	public function delete($id);
}

class AbbigliamentoDAOImp implements AbbigliamentoDAO
{
	public function getAll()
	{

		$abbigliamentoJSON = __DIR__ . "/../../public/data/abbigliamento.json";
		$abbigliamento = json_decode(file_get_contents($abbigliamentoJSON), true);
		$magliette = [];
		foreach ($abbigliamento as $item) {
			$magliette[] = new TShirt(1, $item['nome'], $item['prezzo'], $item['categoria']);
		}

		return $magliette;

		return [
			new TShirt(1, 'T-Shirt Bianca', 19.99, 'Una maglietta bianca classica'),
			new TShirt(2, 'T-Shirt Nera', 24.99, 'Una maglietta nera elegante'),
			new TShirt(3, 'T-Shirt Rossa', 22.99, 'Una maglietta rossa vivace'),
		];
	}

	public function getById($id)
	{
		// Implementazione per recuperare un articolo di abbigliamento per ID
	}

	public function save($item)
	{
		// Implementazione per salvare un articolo di abbigliamento
	}

	public function delete($id)
	{
		// Implementazione per eliminare un articolo di abbigliamento per ID
	}
}