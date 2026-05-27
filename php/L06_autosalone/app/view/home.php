<h1>Home</h1>

<?php

if (isset($_SESSION['logged_in'])) {
	echo 'Welcome back, ' . $_SESSION['username'] . '!';

	include_once (VIEW . 'automobili.php');
} else {
	include_once (VIEW . 'form_login.php');
}
?>