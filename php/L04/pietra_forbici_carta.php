<?php

$simboli = ['pietra', 'forbici', 'carta'];

// $simboli = array("pietra" , "forbici", "carta");
// $simboli[] = "lizard"; // aggiunge un nuovo elemento in coda all'array

// $player1 = scelta($simboli);

function scelta($simboli)
{
	$index = rand(0, count($simboli) - 1);
	return $simboli[$index];
}
	
function valuta($simbolo1, $simbolo2)
{
	if ($simbolo1 == $simbolo2) {
		return 'Pareggio';
	}
	if (
		($simbolo1 == 'pietra' && $simbolo2 == 'forbici') ||
		($simbolo1 == 'forbici' && $simbolo2 == 'carta') ||
		($simbolo1 == 'carta' && $simbolo2 == 'pietra')
	) {
		return 'Player 1 vince';
	} else {
		return 'Player 2 vince';
	}
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
</head>
<body>
	<div class="container">
		<h1>Gioco di Pietra, Forbici, Carta</h1>
		<div class="umano">
			<a href="?player1=pietra">Pietra</a>
			<a href="?player1=forbici">Forbici</a>
			<a href="?player1=carta">Carta</a>

			<?php
			$player1 = $_GET['player1'] ?? scelta($simboli);
			echo "Player 1: $player1\n";
			?>
		</div>
		<div class="macchina">
			<?php
			$player2 = scelta($simboli);
			echo "Player 2: $player2\n";
			?>
		</div>
		<div class="result">
			<?php
			$result = valuta($player1, $player2); ?>
			<h2><?= $result ?></h2>
		</div>
	</div>


</body>
</html>