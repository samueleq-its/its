<?php

// Esercizio 9 – Tabellina del 2 con While
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
	

	<table>
		<th>n</th>
		<th>n * 2</th>
		<tbody>
<?php
$i = 0;
while ($i <= 10) {
?>
			<tr>
				<td><?= $i ?></td>
				<td><?= $i * 2 ?></td>
			</tr>

<?php
	$i++;
}
?>
		</tbody>
	</table>
</body>
</html>