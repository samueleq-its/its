<?php

namespace APP\controller;

use APP\model\Automobile;
use APP\repos\AutomobileRepository;
use APP\repos\MotociclettaRepository;

class AutomobileCtrl
{
	public function __construct()
	{
		$this->automobileRepository = new AutomobileRepository();
		$this->motociclettaRepository = new MotociclettaRepository();
	}

	public function createAutomobile($id, $marca, $modello, $cilindrata, $prezzo)
	{
		return new Automobile($id, $marca, $modello, $cilindrata, $prezzo);
	}

	public function getAutomobili()
	{
		$veicoli = $this->automobileRepository->findAll();
		$titolo = 'Automobili';
		include __DIR__ . '/../view/header.php'; // dir è la cartella del controller
		include __DIR__ . '/../view/veicoli.php';  
		include __DIR__ . '/../view/footer.php';
	}

	public function getMoto()
	{
		$veicoli = $this->motociclettaRepository->findAll();
		$titolo = 'Motociclette';
		include __DIR__ . '/../view/header.php';
		include __DIR__ . '/../view/veicoli.php';
		include __DIR__ . '/../view/footer.php';
	}

	public function getAll(){
		$veicoli = array_merge($this->automobileRepository->findAll(), $this->motociclettaRepository->findAll());
		$titolo = 'Veicoli';
		include __DIR__ . '/../view/header.php';
		include __DIR__ . '/../view/veicoli.php';
		include __DIR__ . '/../view/footer.php';
	}
}
