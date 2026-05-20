<?php

$TOKEN = '123';

// $token = $_GET['token'] ?? '';

if (!isset($_GET['token'])) {
	http_response_code(401);
	$response = [];
	$response['success'] = false;
	$response['message'] = 'missing auth';
	echo json_encode($response);
	exit;
}

$token = $_GET['token'];
if ($token != $TOKEN) {
	http_response_code(401);
	$response = [];
	$response['success'] = false;
	$response['message'] = 'missing auth';
	echo json_encode($response);
	exit;
}
