<?php

$file_path = "../appello.php";

if (!file_exists($file_path)) {
	echo "il file non esiste";
	return;
}
echo date("F d Y H:i:s.", filemtime($file_path));

