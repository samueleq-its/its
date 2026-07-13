<?php

namespace App\Repos;

use App\Models\Paese;
use PDO;

class PaesiRepo
{
	private $pdo;

	public function __construct()
	{
		$this->pdo = new PDO('mysql:host=localhost;dbname=quiz_paesi', 'root', 'root');
		$this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		$this->pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
	}

	public function findAll()
	{
		$statement = $this->pdo->query('SELECT * FROM countries');

		$paesi = [];

		while ($row = $statement->fetch()) {
			$paesi[] = new Paese(
				$row['name'],
				$row['capital'],
				$row['population'],
				$row['alpha2Code'],
			);
		}
		return $paesi;
	}
}
