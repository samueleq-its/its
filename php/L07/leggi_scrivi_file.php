<?php

$file = 'C:\file\che\non\esiste';

// $contents = file_get_contents($file);
// OUTPUT:
// NOTA: è in WARNING non un ECCEZIONE
// Warning: file_get_contents(C:\file\che\non\esiste): Failed to open stream: No such file or directory in C:\Users\samuele.querio\Documents\GitHub\its\php\L07\leggi_scrivi_file.php on line 5

try {
	if (!file_exists($file)) {
		throw new Exception('il file non esiste');
	}
	$contents = file_get_contents($file);
} catch (Exception $eccezione) {
	echo 'errore lettura file: ' . $eccezione->getMessage();
}
// OUTPUT:
// errore lettura file: il file non esiste
