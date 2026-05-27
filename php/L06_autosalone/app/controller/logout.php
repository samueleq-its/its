<?php

function logout()
{
	if (!$_SESSION['logged_in'] ?? false) {
		return;
	}
	
	// Rimuovi le variabili di sessione
	unset($_SESSION['logged_in']);
	unset($_SESSION['username']);

	// Distruggi la sessione
	session_destroy();
}
