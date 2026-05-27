<?php if (!isset($_SESSION['logged_in']) && !$_SESSION['logged_in'] === true): ?>
    <p>Devi essere loggato per visualizzare questa pagina.</p>

<?php else: ?>
    <h1>Automobili</h1>
    <div class="cardbox">

        <?php
	$url = 'https://raw.githubusercontent.com/maboglia/ProgrammingResources/refs/heads/master/tabelle/csv/auto.json';

	$json = file_get_contents($url);
	$json = json_decode($json, true);
	foreach ($json as $auto) {
		echo "<article class='card'>";
		echo '<h2>' . $auto['Marca'] . ' ' . $auto['Modello'] . '</h2>';
		echo '<p>Cilindrata: ' . $auto['Cilindrata (cc)'] . '</p>';
		echo '<p>Prezzo: ' . $auto['Prezzo (€)'] . '€</p>';
		echo '</article>';
	}
	?>

</div>

<?php endif; ?>