<h1> <?= $title ?></h1>

<?php foreach ($magliette as $maglietta): ?>
	<article class="card">
		<header>
			<h2><?= $maglietta->nome ?></h2>
		</header>
		<p>Categoria: <?= $maglietta->categoria ?></p>
		<p>Prezzo: <?= $maglietta->prezzo ?></p>
	</article>
<?php endforeach; ?>
