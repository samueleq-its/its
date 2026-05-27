	<h1><?=$titolo?></h1>
	<table>
		<thead>
			<tr>
				<th>Marca</th>
				<th>Modello</th>
				<th>Cilindrata</th>
				<th>Prezzo</th>
			</tr>
		</thead>
		<tbody>
			<?php foreach ($veicoli as $veicolo): ?>
			<tr>
				<td><?php echo $veicolo->marca; ?></td>
				<td><?php echo $veicolo->modello; ?></td>
				<td><?php echo $veicolo->cilindrata; ?></td>
				<td><?php echo $veicolo->prezzo; ?></td>
			</tr>
			<?php endforeach; ?>
		</tbody>
	</table>
