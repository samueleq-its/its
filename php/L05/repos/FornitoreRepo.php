<?php

include_once ('../model/Fornitore.php');

class FornitoreRepo
{
	private array $fornitori = [];

	public function __construct()
	{
		$this->fornitori = $this->caricaFornitori();
	}

	private function caricaFornitori()
	{
		$fileFornitori = file_get_contents('../database/fornitori.json');
		return json_decode($fileFornitori, true);
	}

	public function aggiungiFornitore(Fornitore $fornitore)
	{
		$this->fornitori[] = $fornitore;
	}

	public function getFornitori(): array
	{
		return $this->fornitori;
	}

	public function getFornitoreById(int $id)
	{
		foreach ($this->fornitori as $fornitore) {
			if ($fornitore['id_fornitore'] === $id) {
				return $fornitore;
			}
		}
		return null;  // Restituisce null se non viene trovato un fornitore con l'ID specificato
	}

	public function updateFornitore(Fornitore $fornitore)
	{
		foreach ($this->fornitori as $index => $f) {
			if ($f->idFornitore === $fornitore->idFornitore) {
				$this->fornitori[$index] = $fornitore;
				return;
			}
		}
	}

	public function deleteFornitore(int $id)
	{
		foreach ($this->fornitori as $index => $fornitore) {
			if ($fornitore->idFornitore === $id) {
				unset($this->fornitori[$index]);
				return;
			}
		}
	}
}
