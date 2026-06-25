<?php

namespace App\Controllers;

use App\Repos\AbbigliamentoDAOImp;
use App\Models\TShirt;

class HomeController
{
	public function index()
	{
		// echo view('home');

		$title = 'Vestiti';

		$dao = new AbbigliamentoDAOImp();
		$magliette = $dao->getAll();

		include_once __DIR__ . '/../Views/Main/header.php';
		include_once __DIR__ . '/../Views/Main/menu.php';
		include_once __DIR__ . '/../Views/Magliette/index.php';
		include_once __DIR__ . '/../Views/Main/footer.php';
	}
}
