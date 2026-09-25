<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Battaglia Navale - Acme Corp</title>
<link rel="stylesheet"
	href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css">
<style>
	.grid-battaglia {
		display: grid;
		grid-template-columns: repeat(5, 1fr);
		gap: 8px;
		max-width: 360px;
		margin: 20px auto;
	}
	.cell-navale {
		height: 60px;
		font-size: 1.5rem;
		display: flex;
		align-items: center;
		justify-content: center;
		margin: 0;
		padding: 0;
	}
</style>
</head>
<body>
<div class="container">
	<nav>
	  <ul>
	    <li><strong>Acme Corp</strong></li>
	  </ul>
	  <ul>
	    <li><a href="home">Home</a></li>
	    <li><a href="tris">Tris</a></li>
	    <li><a href="battaglia-navale">Battaglia navale</a></li>
	  </ul>
	</nav>

	<h1>Battaglia Navale</h1>

	<article class="text-center">
		<h3 id="status">Trova le 4 navi nascoste nella griglia!</h3>
		<p>
			Colpi sparati: <strong id="attempts">0</strong> | 
			Navi affondate: <strong id="hits">0</strong>/4
		</p>
		
		<div class="grid-battaglia" id="board"></div>

		<button class="secondary" onclick="initGame()" style="margin-top: 1rem;">Nuova Partita</button>
	</article>
</div>

<script>
	const GRID_SIZE = 25; // Griglia 5x5
	const TOTAL_SHIPS = 4;
	let shipPositions = new Set();
	let hits = 0;
	let attempts = 0;
	let gameOver = false;

	function initGame() {
		const boardEl = document.getElementById('board');
		boardEl.innerHTML = '';
		shipPositions.clear();
		hits = 0;
		attempts = 0;
		gameOver = false;

		document.getElementById('hits').textContent = hits;
		document.getElementById('attempts').textContent = attempts;
		document.getElementById('status').textContent = `Trova le ${TOTAL_SHIPS} navi nascoste nella griglia!`;

		// Genera posizioni casuali per le navi
		while (shipPositions.size < TOTAL_SHIPS) {
			const randomPos = Math.floor(Math.random() * GRID_SIZE);
			shipPositions.add(randomPos);
		}

		// Disegna la griglia
		for (let i = 0; i < GRID_SIZE; i++) {
			const btn = document.createElement('button');
			btn.className = 'cell-navale outline';
			btn.onclick = () => handleShoot(btn, i);
			boardEl.appendChild(btn);
		}
	}

	function handleShoot(btn, index) {
		if (gameOver || btn.disabled) return;

		attempts++;
		document.getElementById('attempts').textContent = attempts;
		btn.disabled = true;

		if (shipPositions.has(index)) {
			hits++;
			btn.textContent = '💥';
			btn.classList.remove('outline');
			btn.classList.add('contrast');
			document.getElementById('hits').textContent = hits;

			if (hits === TOTAL_SHIPS) {
				document.getElementById('status').textContent = `Vittoria! Navi affondate in ${attempts} colpi! 🎉`;
				gameOver = true;
			}
		} else {
			btn.textContent = '🌊';
			btn.classList.remove('outline');
			btn.classList.add('secondary');
		}
	}

	// Inizializza il gioco all'apertura della pagina
	initGame();
</script>
</body>
</html>