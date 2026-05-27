<?php

$pagina = $_GET['pagina'] ?? 'home';

switch ($pagina) {
	case 'home':
		include_once (VIEW . 'home.php');
		break;
	case 'about':
		include_once (VIEW . 'about.php');
		break;
	case 'logout':
		include_once (CONTROLLER . 'logout.php');
		logout();
		break;
	case 'contact':
		include_once (VIEW . 'contact.php');
		break;
	case "products":
		include_once (VIEW . 'automobili.php');
		break;
	default:
		include_once (VIEW . '404.php');
		break;
}
