<?php declare(strict_types=1);

$numero = 5;

// if ($numero > 0){
// 	echo "$numero è positivo";
// } elseif ($numero < 0) {
// 	echo "$numero è negativo";
// } else {
// 	echo "$numero è zero";
// }

// $msg = match (true) {
// $numero > 0 => "$numero è positivo",
// $numero < 0 => "$numero è negativo",
// default => "$numero è zero"
// };

$msg = match ($numero <=> 0) {
	1 => "$numero è positivo",
	0 => "$numero è zero",
	-1 => "$numero è negativo"
};

echo $msg;
