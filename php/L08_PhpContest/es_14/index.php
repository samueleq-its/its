<?php
// Esercizio 14 – Visualizzare dati in una tabella

include "head.php";

$fileRemoto = "https://raw.githubusercontent.com/maboglia/ProgrammingResources/refs/heads/master/tabelle/games/games.csv";

$arrayRighe = file($fileRemoto);

echo "<table>";

$intestazione = explode(",",array_shift($arrayRighe));
foreach ($intestazione as $column) {

		echo "<th>" .$column . "</th>";
	}

	echo "<tbody>";
foreach($arrayRighe as $riga) {
	$dati = explode(",", $riga);
	echo "<tr>";
	foreach ($dati as $key => $column) {
		if ($key == 0){
			$column = "<a target = '_blank' href = 'https://www.google.com/search?q=$column'>$column</a>";
		}
		echo "<td>" .$column . "</td>";
	}
	echo "</tr>";	
}
echo "</tbody>";
echo "</table>";

include "foot.php";
?>