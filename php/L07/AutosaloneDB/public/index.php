<?php

require_once __DIR__ . '/../vendor/autoload.php';

use APP\controller\AutomobileCtrl;

$ctrl = new AutomobileCtrl();

$pagina = $_GET['p'] ?? 'automobili';

switch ($pagina) {
	case 'automobili':
		$ctrl->getAutomobili();
		break;
	case 'moto':
		$ctrl->getMoto();
		break;
	case 'all':
		$ctrl->getAll();
		break;
	case '':
	default:
		$ctrl->getAutomobili();
		break;
}
