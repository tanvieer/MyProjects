<?php
	$dusername = "";
	$dpassword = "";
	$dfname = "";
	$dlname = "";
	$dadmin = 0;

	$username = "";
	$password = "";

	include("../model/db.php");
	include("./VerifySession.php");


	if( $_SERVER["REQUEST_METHOD"] == "POST" ) {
		if($_POST["username"]) {
			$username = mysql_real_escape_string( trim($_POST["username"]));
		}
		
		if($_POST["password"]) {
			$password = mysql_real_escape_string( trim($_POST["password"]));
		}
		
		if( $username != "" && $password != "" ) {
		
			if($username == $dusername && $password == $dpassword ) {
				
				if( !verify($username, $password) ) {
					saveCredentials($username, $password , $dfname , $dlname, $dadmin);
				}
				
				header("Location: ../view/home.php");
			} 
			else {
				echo "Invalid Username Password";
				header("Location: ../view/login.php");
			}
			
			if($username != $dusername) $username = "";
			if($password != $dpassword) $password = "";
		}
	}
?>