<?php


	include("../model/dbconnection.php");
	

	function getTotalSeat($code){
		$sql = "SELECT seat FROM businfo where code = '$code'";
		$result =  $GLOBALS['conn']->query($sql);
		while($data =  $result->fetch_assoc())
		{ 
			return $data["seat"];
		}
	}


	function buySeat($code,$num_seat){

		$temp = getTotalSeat($code) - $num_seat;
		if($temp <0) {
			echo "<h2>Seat not available</h2>";
			return false;
		}
		else if($num_seat >0){
			if($temp == 0 ) $available = 0; else $available = 1;

			$sql = "UPDATE businfo SET seat = '$temp' , avaiable = '$available' WHERE businfo.code = '$code'";
				if ($GLOBALS['conn']->query($sql)) {
			    echo "<h2>Congratualtion Your Ticket Booked Successfully.</h2>";
			} 
			else {
			    echo "Error updating record: " . $conn->error;
			}
		}
		else echo "Please fillup all with valid input.";
		


	}


	$buscode = $_REQUEST["q"];
	$num_seat = $_REQUEST["st"];

	buySeat($buscode,$num_seat);
	



?>