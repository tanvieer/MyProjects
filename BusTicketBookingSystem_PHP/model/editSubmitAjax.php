<?php
	$headers = apache_request_headers();
	if(!isset( $headers["Referer"] )){
		die("Directory access is forbidden.");
	}
	// if(isset( $headers["Referer"] )){
	// 	if($headers["Referer"] != "http://localhost/Webtechfinal/view/EditRouteDB.php?p=".$_REQUEST['cd']){
	// 			die("Directory access is forbidden.");
	// 	 }
    	
	// }
?>


<?php
	include('./../controller/VerifySession.php');
	if( !ifCredentialSaved() && $_SESSION['admin']==0) {
		header("Location: ./../controller/logout.php");
	}
	include("../model/dbconnection.php");

    $status = true;
    	if($_REQUEST['cd']) $code = mysql_real_escape_string( trim($_REQUEST['cd'])); else $status = false;
	    if($_REQUEST['st']) $seat  = mysql_real_escape_string( trim($_REQUEST['st'])); else $status = false;
	    if($_REQUEST['dp']) $departing = mysql_real_escape_string( trim($_REQUEST['dp'])); else $status = false;
	    if($_REQUEST['ar']) $arival = mysql_real_escape_string( trim($_REQUEST['ar'])); else $status = false;
	    if($_REQUEST['tf']) $ticketfare  = mysql_real_escape_string( trim($_REQUEST['tf']));  else $status = false;
	    if($_REQUEST['sc']) $startcounter = mysql_real_escape_string( trim($_REQUEST['sc']));  else $status = false;   
	    if($_REQUEST['ec']) $endcounter  = mysql_real_escape_string( trim($_REQUEST['ec'])); else $status = false;
	    $available = $_REQUEST['av']; 

	    if (strlen($departing) != 5) $status = false;
	    if (strlen($arival) != 5) $status = false;
	    if ($available < 0) $status = false;
	    if ($available > 1) $status = false;
	    //echo "checking = ".$available." status = ".$status;
	    if($seat < 1) $available = 0;
	    if($seat < 0) $status = false;


    	if($seat>-1 && strlen($departing) > 4 && $departing != $arival && strlen($arival) > 4 && strlen($ticketfare) > 2 && strlen($startcounter) > 1 && strlen($endcounter) > 1 && strlen($available) > 0 && $startcounter != $endcounter && $status){
		    $sql = "UPDATE businfo SET seat = '$seat', departing = '$departing', arival = '$arival', ticketfare = '$ticketfare', startcounter = '$startcounter', endcounter = '$endcounter', avaiable = '$available' WHERE code ='$code';";

			if ($conn->query($sql) === TRUE) {
			    echo "Record updated successfully";
			} else {
			    echo "Error updating record: " . $conn->error;
			}
		}
		else echo "Invalid Inpiut";

	$conn->close();

?>