<?php

if (!isset($_POST['username']) || !isset($_POST['password'])) {
	return;
}

$username = $_POST['username'];
$password = $_POST['password'];

if ($username === 'admin' && $password === '12345') {
	$_SESSION['logged_in'] = true;
	$_SESSION['username'] = $username;
	header('Location: ?pagina=home');
	exit();
} else {
	echo '<script>alert("Invalid username or password")</script>';
}
