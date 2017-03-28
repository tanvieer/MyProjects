<?php 
	include('./../controller/VerifySession.php');
    
    if( !ifCredentialSaved() && $_SESSION['admin']==0) {
        header("Location: ./../controller/logout.php");
    }


	include("../model/dbconnection.php");
	$code = $_REQUEST['p']; 

	//print_r ($_POST); 
	//print_r ($_GET); 
	//print_r ($_REQUEST); 
	//print_r ($GLOBALS);

	$sql = "SELECT * FROM businfo where code = '$code'";
		$result = $conn->query($sql) or die ("failed to query from EditRouteDB.php line 15");
		$row = $result->fetch_assoc();

		$code = $row["code"];
		$seat = $row["seat"];
		$departing = $row["departing"];
		$arival = $row["arival"];
		$ticketfare = $row["ticketfare"];
		$startcounter = $row["startcounter"];
		$endcounter = $row["endcounter"];
		$available = $row["avaiable"];
 ?>




<!DOCTYPE html>
<html>
<head>
	<title>ADMIN Edit Page</title>
     <style type="text/css">
        
        <style type="text/css">


        ul {
            list-style-type: none;
        }
        
        table {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
            border: 2px solid #ddd;

        }
        th {
            background-color: #A9A9A9;
            text-align: center;
            padding: 9px;
            font-weight: bold;
        }

        td {
            border: none;
            text-align: center;
            padding: 7px;
            font-weight: bold;
        }

        tr:nth-child(even){background-color: #f2f2f2}

	.head {
		background-color: #A9A9A9;
		color: black;
	}
	#nam {
		text-transform: uppercase;
		font-weight: bold;
	}
	#head1 {
		padding: 5px;
		background-color: 	#E6E6FA;
	}

	body {
    	background: url("../res/images/bus.png");
    	background-size: 40%;
    	background-repeat: no-repeat;
    	background-attachment: fixed;
    	background-position: center; 
	}
	 #hm {
	    	float: left;
	    	margin-left: 10px;
	    }
/*============================================================================================*/
	.panel {
	    padding: 5px;
	    text-align: center;
	    background-color: #e5eecc;
	    border: solid 1px #c3c3c3;
	    padding: 50px;
	    display: none;
	}

	.sub-container {
		background-color: #e5eecc;
	}




/*==============================================================================================*/

	#confirmMSG{
		color: blue;
		text-align: center;
	}
    #confirmedit {
    	width: 15%;
    	padding: 5px;
    	margin: 1px;
    }
    input {
    	width: 80%;
    }  
    </style>



    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../controller/adminhome.js"></script>



</head>








<body>
<div id="sub-container">
	<div class = "head">
	<br>
		<a href="./adminhome.php" id = "hm">HOME</a>
		<center><span>Welcome  <span id ="nam"><?php echo $_SESSION['dfname']." ".$_SESSION['dlname'];?>  </span>	</span><a href="../controller/logout.php">Log Out</a></center>
	<br>
	</div>

	<?php


	 echo "<div >";
	 echo " <table id='BusRoute' name = 'BusRoute'>";
	 echo "   <tr>";
	 echo "<th>DEPARTING TIME</th>";
	 echo "     <th>COACH NO</th>";
	 echo "     <th>STARTING COUNTER</th>";
	 echo "     <th>END COUNTER</th>";
	 echo "     <th>FARE</th>";
	 echo "     <th>ARRIVAL TIME</th>";
	 echo "     <th>SEATS AVAILABLE</th>";
	 echo "     <th>AVAILABLE</th>";
	 echo "   </tr>";


	    echo "<tr>";
		 echo "<td align=center> <input type='text' name='departing' id='departing' value='$departing'> </td>";
		 echo "<td align=center>$code</td>";
		 echo "<td align=center> <input type='text' name='startcounter' id='startcounter' value='$startcounter'> </td>";
		 echo "<td align=center> <input type='text' name='endcounter' id='endcounter' value='$endcounter'> </td>";
		 echo "<td align=center> <input type='text' name='ticketfare' id='ticketfare' value='$ticketfare'> </td>";
		 echo "<td align=center> <input type='text' name='arival' id='arival' value='$arival'> </td>";
		 echo "<td align=center> <input type='text' name='seat' id='seat' value='$seat'> </td>";
		 echo "<td align=center> <input type='text' name='available' id='available' value='$available'> </td>";
	    echo "</tr>";

	echo "</table>";
	echo "</div>";
	echo "<h3 id = 'confirmMSG'><br></h3>";
	echo "<center><input type='button' name='confirmedit' id= 'confirmedit' value ='CONFIRM' action ='confirmeditDB()' >";
	echo "<input type='button' id= 'confirmedit' onclick='refresh()' value ='BACK'> </center>";

	echo "<p class='panel' id = 'cod'>$code</p>";

?>

</div>



</body>
</html>