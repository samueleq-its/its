<?php

$vestiti = array('camicia', 'pantaloni', 'giacca', 'scarpe');
print_r($vestiti);
// OUTPUT:
// Array
// (
//     [0] => camicia
//     [1] => pantaloni
//     [2] => giacca
//     [3] => scarpe
// )

$vestiti[97] = 'cappello';
$vestiti[] = 'foulard';
print_r($vestiti);
// OUTPUT:
// Array
// (
//     [0] => camicia
//     [1] => pantaloni
//     [2] => giacca
//     [3] => scarpe
//     [97] => cappello
//     [98] => foulard
// )

for ($i = 0; $i < count($vestiti); $i++) {
	echo $vestiti[$i] . "\n";
}
// OUTPUT:
// camicia
// pantaloni
// giacca
// scarpe
// PHP Warning:  Undefined array key 4 in C:\Users\samuele.querio\Documents\GitHub\its\php\L07\sintassi_base.php on line 29