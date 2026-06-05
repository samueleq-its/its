<?php

// LIVELLO 8 – Array Associativi
// Esercizio 18 – Province e sigle
// Obiettivo
// Creare un array associativo contenente:

// Provincia
// Sigla

// Quindi mostrare una tendina (select) html con nome della provincia e sigla come value,
// inviare il form e verificare il corretto funzionamento

$provincie = [
	["sigla" => 'TO', "nome" => 'Torino'],
	["sigla" => 'MI', "nome" => 'Milano'],
	["sigla" => 'RM', "nome" => 'Roma'],
	["sigla" => 'NA', "nome" => 'Napoli'],
	["sigla" => 'FI', "nome" => 'Firenze'],
	["sigla" => 'VE', "nome" => 'Venezia']
];

$scelta = $_GET["provincia"] ?? null;

?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
	<link
	rel="stylesheet"
	href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css"
	>
</head>
<body>
	<div class="container">
		<form action="" method="get">
			<label for="provincia">Provincia:</label>
			<select name="provincia" id="provincia">
			<?php foreach($provincie as ["sigla" => $id, "nome" =>  $nome]): ?>

				<option value=<?=$id?>><?=$nome?></option>

			<?php endforeach; ?>
			</select>
			<button>invia</button>
		</form>
		<?php if ($scelta): ?>
		<article>
			hai scelto <?=$scelta?>
		</article>
		<?php endif; ?>
	</div>
</body>
</html>