<?php

$url = 'https://raw.githubusercontent.com/maboglia/ProgrammingResources/refs/heads/master/tabelle/libri/Biblioteca.csv';

$file_libri = file($url);

// var_dump($file_libri);
// print_r($file_libri);

$output = "";

$file_libri = array_slice($file_libri, 1); // Rimuove la prima riga (intestazione)
$file_libri = array_slice($file_libri, 0, 20); // Prende solo le prime n righe
foreach ($file_libri as $line) {
	$libro = explode(',', $line);
	$output .= "aggiungiLibro(new Libro(\"" . trim($libro[2]) . "\",";
	$output .= "\"" . trim($libro[1]) . "\",";
	$output .= "" . (is_int(trim($libro[4])) ? trim($libro[4]) : 0) . "));\n";
}

$output = str_replace('""', '"', $output);

file_put_contents('libri.php', "{\n" . $output . "\n}");
