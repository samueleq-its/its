<?php
require_once 'init.php';

http_response_code(200);
$response = [];
$response['success'] = true;
$response[] = 'bla';
$response[] = 'bla2';
$response[] = 'bla3';
echo json_encode($response);
