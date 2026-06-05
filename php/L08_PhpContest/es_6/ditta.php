<?php declare(strict_types=1);

class Ditta
{
	function __construct(
		private string $Nome,
		private string $Ragionesociale,
		private string $Indirizzo,
		private string $Partitaiva
	) {}

	public function __toString(): string
	{
		return "Ditta: $this->Nome, $this->Ragionesociale, $this->Indirizzo, $this->Partitaiva";
	}
}

if (!isset($_POST['Nome']) || !isset($_POST['Ragionesociale']) || !isset($_POST['Indirizzo']) || !isset($_POST['Partitaiva'])) {
	// echo "dati mancanti";
} else if ($_POST['Nome'] == '' || $_POST['Ragionesociale'] == '' || $_POST['Indirizzo'] == '' || $_POST['Partitaiva'] == '') {
	// echo "dati vuoti";
} else {
	['Nome' => $nome, 'Ragionesociale' => $ragionesociale, 'Indirizzo' => $indirizzo, 'Partitaiva' => $partitaiva] = $_POST;
	$ditta = new Ditta(
		Nome: $nome,
		Ragionesociale: $ragionesociale,
		Indirizzo: $indirizzo,
		Partitaiva: $partitaiva
	);
}

include("html.php");
?>

