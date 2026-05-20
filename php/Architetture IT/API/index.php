<?php

require_once 'init.php';

$USERNAME = 'admin';
$PASSWORD = 'admin';
$TOKEN = '123';

if (!isset($_GET['username']) || !isset($_GET['password'])) {
	http_response_code(401);
	$response = [];
	$response['success'] = false;
	$response['message'] = 'missing username or password';
	echo json_encode($response);
	exit;
}

$username = $_GET['username'];
$password = $_GET['password'];

if ($username != $USERNAME || $password != $PASSWORD) {
	http_response_code(401);
	$response = [];
	$response['success'] = false;
	$response['message'] = 'wrong username or password';
	echo json_encode($response);
	exit;
}

http_response_code(200);
$response = [];
$response['success'] = true;
$response['token'] = $TOKEN;
echo json_encode($response);
