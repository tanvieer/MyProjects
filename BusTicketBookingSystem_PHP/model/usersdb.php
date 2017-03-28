<?php
	function insertIntoUsers ($uname , $pass) {
		$servernamei = "localhost";
		$susernamei = "root";
		$spasswordi = "";
		$dbi = "login";
		$conn = mysqli_connect($servernamei, $susernamei, $spasswordi, $dbi);

		if (!$conn) {
		    die("Connection failed: " . mysqli_connect_error());
		}

		if(strlen($uname) >0 && strlen($pass)>0){
			$sql = "INSERT INTO users (username, password) VALUES ('$uname', '$pass');";

			if (mysqli_query($conn, $sql)) {
			    return true;
			} else {
			    echo "Error: " . $sql . "<br>" . mysqli_error($conn);
			    return false;
			}
		}else echo "Invalid Input!!";
	}

?>