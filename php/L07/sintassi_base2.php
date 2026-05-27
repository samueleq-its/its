<?php

$vestiti = 'camicia';

echo $vestiti . "\n";
// OUTPUT:
// camicia

// $$ variabile di variabile

$camicia = 'pantaloni' . "\n";
echo $$vestiti;
// OUTPUT:
// pantaloni


// &$ variabile di riferimento
// passa il puntatore alla variabile, non una copia del suo valore

$puntatore = &$vestiti;
$puntatore = 'giacca';
echo $vestiti . "\n";
// OUTPUT:
// giacca