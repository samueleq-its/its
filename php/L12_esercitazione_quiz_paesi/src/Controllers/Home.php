<?php

namespace App\Controllers;

use App\Model\Paese;
use App\Repos\PaesiRepo;

class Home
{
	public function index()
	{
		$title = 'home';

		$repo = new PaesiRepo();
		$countries = $repo->findAll();

		// creazione quiz paese - capitale
		$difficulty = 3;  // 1 (easy) - 3 (hard)

		$countryAnswer = $countries[array_rand($countries)];
		$countriesWrong = [];

		foreach (array_rand($countries, $difficulty) as $index) {
			$countriesWrong[] = $countries[$index];
		}

		include_once __DIR__ . '\..\Views\Main\header.php';
		include_once __DIR__ . '\..\Views\Main\menu.php';

		echo "<div> qual'è la capitale del " . $countryAnswer->__get('name') . '?</div>';
		echo '<button>' . $countryAnswer->__get('capital') . '</button>';
		foreach ($countriesWrong as $wrong) {
			echo '<button>' . $wrong->__get('capital') . '</button>';
		}

		include_once __DIR__ . '\..\Views\Main\footer.php';
	}
}
