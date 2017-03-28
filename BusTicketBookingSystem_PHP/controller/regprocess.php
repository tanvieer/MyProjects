<?php
	if( !isset($_SESSION) ) {
		session_start();
	}
	session_unset();
	session_destroy();
include("../model/regdb.php");
/*
	echo '$_SERVER["REQUEST_METHOD"]: ' . $_SERVER["REQUEST_METHOD"];
		
	echo '$_POST["username"]: ' . $_POST["username"];
	echo '$_POST["password"]: ' . $_POST["password"];

	*/

$username ="";
$fname = "";
$lname = "";
$phone = "";
$email = "";

$password = "";
$cpassword = "";



if( $_SERVER["REQUEST_METHOD"] == "POST" ) {
	if($_POST["fname"]) {
		$fname = mysql_real_escape_string( trim( $_POST["fname"] ));
	}
	if($_POST["lname"]) {
		$lname = mysql_real_escape_string( trim( $_POST["lname"] ));
	}
	if($_POST["username"]) {
		$username = mysql_real_escape_string( trim( $_POST["username"] ));
	}
	if($_POST["email"]) {
		$email = mysql_real_escape_string( trim( $_POST["email"] ));
	}
	if($_POST["phone"]) {
		$phone = mysql_real_escape_string( trim( $_POST["phone"] ));
	}
	
	if($_POST["username"]) {
		$username = mysql_real_escape_string( trim( $_POST["username"] ));
	}
	
	if($_POST["password"]) {
		$password = mysql_real_escape_string( trim( $_POST["password"] ));
	}
	if($_POST["cpassword"]) {
		$cpassword = mysql_real_escape_string( trim( $_POST["cpassword"] ));
	}
	
	$isValid = true;
	
	if( $fname != "" && $lname != "" && $email != "" && $phone != "" && $username != "" && $password != "" && $cpassword != "" ) {
	
		if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
			echo 'Invalid EMAIL<br>';
			$isValid = false;
		}
	
		if($password != $cpassword) {
			echo 'The password did not matched!!!<br>';
			$password = $cpassword = "";
			$isValid = false;
		}
		
		
	} else {
		echo 'Please fill up all fields...';
		$isValid = false;
	}

	if(!checkEmail($email)) {
		$isValid = false;
	}

	if(!checkUsername($username)) {
		$isValid = false;
	}

	if($isValid) {
		$isValid = insertIntoUserInfo($username , $fname , $lname , $email , $password ,$phone);
	}

	
	if( $isValid ) {
		setcookie('success', $username, time() + (10), "/");
		setcookie('pass', $password, time() + (10), "/");
		header("Location: ../view/login.php");
	}
	else {
		echo "something wrong, please check again and try again;";
		//header("Location: ../view/registration.php");
	}
}
?>