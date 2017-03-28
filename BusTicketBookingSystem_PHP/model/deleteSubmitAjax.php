<?php
	$headers = apache_request_headers();
	if(!isset( $headers["Referer"] )){
		die("Directory access is forbidden.");
	}

	// if(isset( $headers["Referer"] )){
	// 	echo $headers["Referer"];
	// 	if($headers["Referer"] != "http://localhost/Webtechfinal/view/adminhome.php"){
	// 			die("Directory access is forbidden.");
	// 	 }
    	
	// }

	$code = $_REQUEST['q'];
?>


<?php
	include('./../controller/VerifySession.php');
	if( !ifCredentialSaved() && $_SESSION['admin']==0) {
		header("Location: ./../controller/logout.php");
	}
	include("../model/dbconnection.php");


	if($code>0){
	    $sql = "DELETE FROM businfo WHERE code = '$code'";

		if ($conn->query($sql) === TRUE) {
		    echo "Record Deleted Successfully";
		} else {
		    echo "Error Deleting record: " . $conn->error;
		}
	} else echo "Invalid Coach No.";

	$conn->close();

?>