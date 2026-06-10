<?php

$url = isset($_GET['sezione']) && !empty($_GET['sezione'])
	? 'http://localhost:9001/api/prodotti/sezione/' .str_replace(" ", "%20", $_GET['sezione'])
	: 'http://localhost:9001/api/prodotti';

$listino = json_decode(file_get_contents($url), true);

$sezioni_url = 'http://localhost:9001/api/prodotti/sezioni';
$sezioni = json_decode(file_get_contents($sezioni_url), true);

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
		<h1>Listino prezzi bar</h1>

		<form action="" method="get">
			<label for="sezione">Sezione</label>
			<select name="sezione" id="sezione">
				<option value="">Tutte le sezioni</option>
				<?php foreach ($sezioni as $sezione): ?>
				<option value="<?= $sezione ?>"><?= $sezione ?></option>
				<?php endforeach; ?>
			</select>
			<button>Filtra</button>
		</form>

		<table>
			<tr>
				<th>Prodotto</th>
				<th>Categoria</th>
				<th>Prezzo</th>
			</tr>
			<?php foreach ($listino as $prodotto): ?>
			<tr>
				<td><?php echo $prodotto['prodotto']; ?></td>
				<td><?php echo $prodotto['sezione']; ?></td>
				<td><?php echo $prodotto['prezzo']; ?></td>
			</tr>
			<?php endforeach; ?>
		</table>
	</div>

</body>
</html>