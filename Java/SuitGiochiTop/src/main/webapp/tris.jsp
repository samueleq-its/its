<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Tris - Acme Corp</title>
<link rel="stylesheet"
	href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css">
<style>
	.grid-tris {
		display: grid;
		grid-template-columns: repeat(3, 1fr);
		gap: 10px;
		max-width: 320px;
		margin: 20px auto;
	}
	.cell {
		height: 90px;
		font-size: 2.2rem;
		font-weight: bold;
		display: flex;
		align-items: center;
		justify-content: center;
		margin: 0;
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

	<h1>Tris</h1>

	<article class="text-center">
		<h3 id="status">Turno del Giocatore X</h3>
		<div class="grid-tris">
			<button class="cell outline" onclick="makeMove(this, 0)"></button>
			<button class="cell outline" onclick="makeMove(this, 1)"></button>
			<button class="cell outline" onclick="makeMove(this, 2)"></button>
			<button class="cell outline" onclick="makeMove(this, 3)"></button>
			<button class="cell outline" onclick="makeMove(this, 4)"></button>
			<button class="cell outline" onclick="makeMove(this, 5)"></button>
			<button class="cell outline" onclick="makeMove(this, 6)"></button>
			<button class="cell outline" onclick="makeMove(this, 7)"></button>
			<button class="cell outline" onclick="makeMove(this, 8)"></button>
		</div>
		<button class="secondary" onclick="resetGame()" style="margin-top: 1rem;">Nuova Partita</button>
	</article>
</div>

<script>
	let board = Array(9).fill('');
	let currentPlayer = 'X';
	let active = true;

	const winPatterns = [
		[0,1,2], [3,4,5], [6,7,8],
		[0,3,6], [1,4,7], [2,5,8],
		[0,4,8], [2,4,6]
	];

	function makeMove(btn, index) {
		if (!active || board[index] !== '') return;

		board[index] = currentPlayer;
		btn.textContent = currentPlayer;
		btn.classList.remove('outline');

		if (checkWin()) {
			document.getElementById('status').textContent = `Vittoria del Giocatore ${currentPlayer}! 🎉`;
			active = false;
		} else if (board.every(cell => cell !== '')) {
			document.getElementById('status').textContent = 'Pareggio! 🤝';
			active = false;
		} else {
			currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
			document.getElementById('status').textContent = `Turno del Giocatore ${currentPlayer}`;
		}
	}

	function checkWin() {
		return winPatterns.some(pattern => {
			return pattern.every(index => board[index] === currentPlayer);
		});
	}

	function resetGame() {
		board = Array(9).fill('');
		currentPlayer = 'X';
		active = true;
		document.getElementById('status').textContent = 'Turno del Giocatore X';
		document.querySelectorAll('.cell').forEach(btn => {
			btn.textContent = '';
			btn.classList.add('outline');
		});
	}
</script>
</body>
</html>