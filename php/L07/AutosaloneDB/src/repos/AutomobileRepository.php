<?php
namespace APP\repos;

use APP\model\Automobile;
use PDO;

class AutomobileRepository
{
	private $pdo;

	public function __construct()
	{
		$this->pdo = new PDO('mysql:host=localhost;dbname=autosalone', 'root', 'root');
	}

	/* public function create(Automobile $auto)
	{
		$statement = $this->pdo->prepare('INSERT INTO automobili (id, marca, modello, cilindrata, prezzo) VALUES (:id, :marca, :modello, :cilindrata, :prezzo)');
		$statement->execute([
			'id' => $auto->id,
			'marca' => $auto->marca,
			'modello' => $auto->modello,
			'cilindrata' => $auto->cilindrata,
			'prezzo' => $auto->prezzo
		]);
	} */

	public function findAll()
	{
		$statement = $this->pdo->query('SELECT * FROM automobili');
		//$statement->setFetchMode(PDO::FETCH_CLASS, Automobile::class); // NON FUNZIONA, chiama il costruttore di Automobile senza parametri, ma ne richiede 5

		$automobili = [];
		// non ho capito cosa faccia PDO::FETCH_ASSOC, Automobile::class
		while ($row = $statement->fetch()) {
			$automobili[] = new Automobile(
				$row['id'],
				$row['marca'],
				$row['modello'],
				$row['cilindrata'],
				$row['prezzo']
			);
		}
		return $automobili;
	}
}
