<?php
// include_once("../model/Prodotto.php");
// include_once "../model/Categoria.php";
// include_once "../model/Fornitore.php";
// include_once "../repos/ForinitoreRepo.php";
include_once '../presentation/MagazzinoRest.php';

# TEST PRODOTTO
// $p = new Prodotto(0, "prodottoProva",1.99, 5, new Categoria(0, "categoria"), new Fornitore(0, "fornitore", "Torino", "test@test.com"));
// var_dump($p);

# TEST REPO
// $fornitoreDAO = new ForinitoreRepo();
// print_r($fornitoreDAO->getFornitori());

# TEST REST
// $rest = new MagazzinoRest();
// // API su http://localhost/PHP/L05/demo/test_magazzino.php
// header('Content-Type: application/json');
// echo $rest->getFornitori();

// var_dump($_REQUEST);
// var_dump($_SERVER);

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
	if (isset($_GET['idFornitore'])) {
		$rest = new MagazzinoRest();
		header('Content-Type: application/json');
		echo $rest->getFornitoreById((int)$_GET['idFornitore']);
		
	} else {
		$rest = new MagazzinoRest();
		header('Content-Type: application/json');
		echo $rest->getFornitori();
	}
} else {
	http_response_code(405);  // Method Not Allowed
	echo json_encode(['error' => 'Method not allowed']);
}
