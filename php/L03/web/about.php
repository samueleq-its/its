<h1>About Us</h1>

<p>Welcome</p>

<?php
$contatore = 0;

if (isset($_GET['counter'])) {
	$contatore = $_GET['counter'];
}

// questa è una procedura non una funzione, non ha argomenti ne return, solo effetti collaterali (side effects)
function incrementa()
{
	global $contatore;
	$contatore++;
}

function decrementa()
{
	global $contatore;
	$contatore--;
}

if (isset($_GET['action']) && !empty($_GET['action'])) {
	$action = $_GET['action'];
	if ($action == 'incrementa') {
		incrementa();
	} elseif ($action == 'decrementa') {
		decrementa();
	}
}

?>
<div>
	<a role="button" href="?page=about&action=decrementa&counter=<?= $contatore ?>" class="btn">Decrementa</a>
	<a role="button" href="?page=about&action=incrementa&counter=<?= $contatore ?>" class="btn">Incrementa</a>
</div>

<?php
$elenco = ["spada", "mazza", "azza", "guisarme"]

?>

<h3>Contatore = <?= $contatore ?></h3>

<h4><?= $elenco[abs( $contatore % count($elenco))]?></h4>