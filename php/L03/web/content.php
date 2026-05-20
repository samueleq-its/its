<?php declare(strict_types=1);

$pagina = 'home';

if (isset($_GET['page']) && !empty($_GET['page'])) {
	$pagina = $_GET['page'];
}

switch ($pagina) {
	case 'home':
		include 'home.php';
		break;
	case 'about':
		include 'about.php';
		break;
	case 'services':
		include 'services.php';
		break;
	case 'contact':
		include 'contact.php';
		break;
	default:
		echo 'la pagina richiesta non esiste';
		break;
}

?>

