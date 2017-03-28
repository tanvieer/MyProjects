 <?php
	include("../model/usersdb.php");

	function insertIntoUserInfo($uname , $f_name , $l_name , $emailID , $pass ,$phone){
		$servernamei = "localhost";
		$susernamei = "root";
		$spasswordi = "";
		$dbi = "login";
		$conn = mysqli_connect($servernamei, $susernamei, $spasswordi, $dbi);

		if (!$conn) {
		    die("Connection failed: " . mysqli_connect_error());
		}

		if(strlen($uname)>0 && strlen($f_name)>0 && strlen($l_name)>0 && strlen($emailID)>0 && strlen($pass)>0 && strlen($phone)>0 ){
			$sql = "INSERT INTO userinfo (username, first_name, last_name, phone, email) VALUES ('$uname', '$f_name', '$l_name', '$phone', '$emailID');";
			if (mysqli_query($conn, $sql) && insertIntoUsers ($uname , $pass) ) {
			    //echo "New record created successfully";
			    mysqli_close($conn);
			    return true;
			} else {
			    //echo "Error: " . $sql . "<br>" . mysqli_error($conn);
			    mysqli_close($conn);
			    return false;
			}
		}
		else echo "Invalid Input!!";
		mysqli_close($conn);
	}




	function checkUsername($uname){
		$uname = trim($uname);
		
		include("../model/dbconnection.php");

		$sql = "SELECT username FROM users WHERE username = '$uname'";
		$result = $conn->query($sql);

		if ($result->num_rows > 0) {
		    echo $uname." Username Already Exist!!<br>";
		    $conn->close();
		    return false;
		} else {
			$conn->close();
		    return true;
		}
	}


	function checkEmail($uname){
		$uname = trim($uname);
		
		include("../model/dbconnection.php");

		$sql = "SELECT email FROM userinfo WHERE email = '$uname'";
		$result = $conn->query($sql);

		if ($result->num_rows > 0) {
		    echo $uname." Email Already Exist!!<br>";
		    $conn->close();
		    return false;
		} else {
			$conn->close();
		    return true;
		}
	}

		    	
?> 