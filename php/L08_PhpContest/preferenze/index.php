<?php
session_start();

if (isset($_POST['emptyList'])) {
	unset($_SESSION['series']);
}

$titolo = $_POST['titolo'] ?? null;
if ($titolo) {
	$_SESSION['series'][] = $titolo;
}

$series = $_SESSION['series'] ?? [];

?>
<!DOCTYPE html>
<html lang="en">

<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css">
</head>

<body>
	<div class="container">
		<form action="" method="post">
			<input type="text" name="titolo" id="titolo" placeholder="Titolo Serie">

			<button>invia</button>
		</form>
		<form action="" method="post">
			<button>svuota lista</button>
			<input type="hidden" name="emptyList">
		</form>

		
		<div style="display: flex;">
			<div>
				<h1>lista serie</h1>
			
		<?php foreach ($series as $serie): ?>
				<h3><?= $serie ?></h3>
				<button onclick="showInfo('<?= $serie ?>')">vedi dettagli</button>
		<?php endforeach; ?>
		</div>
		<div style="margin-left: 100px;">
			<h1>Scheda Dettaglio</h1>
			<h2 id="genere"></h2>
			<h2 id="rating"></h2>
			<h2 id="status"></h2>
			<img src="" alt="">
		</div>

	</div>

	<script>
	function showInfo(titolo){
		const url = "https://api.tvmaze.com/singlesearch/shows?q=" + titolo;
		
		fetch(url)
			.then(res => res.json())
			.then(serie => {
				document.getElementById("genere").textContent = serie.genres.join(" ");
				document.getElementById("rating").textContent = serie.rating.average;
				document.getElementById("status").textContent = serie.status;
				document.querySelector("img").src = serie.image.medium;

			})

	}

	</script>
</body>

</html>