<?php
header('Content-Type: application/json');

if (! str_contains($_SERVER['SCRIPT_NAME'] ,'index.php')) {
	require_once 'auth_check.php';
}
