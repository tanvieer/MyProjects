<?php
	include("../controller/VerifySession.php");

	session_unset();
	session_destroy();
	if(isset($_COOKIE['success'])) {
	     setcookie('success', '', time() - 3600, '/');
	}
	if(isset($_COOKIE['pass'])) {
	     setcookie('pass', '', time() - 3600, '/');
	}

	header("Location: ./../view/login.php");
?>