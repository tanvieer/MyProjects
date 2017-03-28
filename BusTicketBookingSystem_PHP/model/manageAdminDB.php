<?php

$headers = apache_request_headers();
	if(!isset( $headers["Referer"] )){
		die("Directory access is forbidden.");
	}

include('./../controller/VerifySession.php');

	if( !ifCredentialSaved() ) {
			if($_SESSION['admin'] != 3) {
			header("Location: ./../controller/logout.php");
		}
	
	}


	




	$uname = $_REQUEST['uname'];
	$action = $_REQUEST['action'];  //1 FOR MAKE ADMIN, 2 FOM MAKE USER, 3 FOR DELETE USER

    include("../model/dbconnection.php");


    if($action==3){
    	$status = true;
	    $sql = "DELETE FROM users WHERE username = '$uname'";

		if (!$conn->query($sql)) {
		    $status = false;
		} 

		$sql = "DELETE FROM userinfo WHERE username = '$uname'";
		if ($conn->query($sql) === TRUE && $status) {
		    echo "User Deleted Successfully";
		} 
		else {
		    echo "Error Deleting record: " . $conn->error;
		}
	} 




    if($action==2){
    	$status = true;
	    $sql = "UPDATE users SET admin = '0' WHERE users.username = '$uname'";

		if ($conn->query($sql)) {
		    echo $uname." is now Normal User.";
		} 
		else {
		    echo "Error Updating record: " . $conn->error;
		}
	}

	if($action==1){
    	$status = true;
	    $sql = "UPDATE users SET admin = '1' WHERE users.username = '$uname'";

		if ($conn->query($sql)) {
		    echo $uname." is now Admin User.";
		} 
		else {
		    echo "Error Updating record: " . $conn->error;
		}
	}


$conn->close();

?>