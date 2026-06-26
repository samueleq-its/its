<?php

//require __DIR__ . "/controller/prodotti.php";

$method = $_SERVER['REQUEST_METHOD'];

$url = trim($_SERVER['REQUEST_URI'], "/");

$parti = explode("/", $url);

$risorsa = $parti[3] ?? "";
$id = $parti[4] ?? null;

header("Content-Type: application/json");

switch ($risorsa) {
	case "prodotti":
		require  __DIR__ . "/controller/prodotti.php";
		break;

	default:
		http_response_code(405);

		echo json_encode([
			"errore" => "$risorsa non disponibile"
		]);
}

