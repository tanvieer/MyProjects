<?php
    include("univarsalheader.php");
?>

<?php
    include('./../view/homeheader.php');
?>
<!DOCTYPE html>
<html>
<head>
	<title>Bus Ticket</title>

		<style rel="stylesheet">
	body {
		text-align: center;
	}
	ul {
    	list-style-type: none;
	}
	.required {
		color: red;
	}
    #report {
        color: blue;
        font-weight: bold;
    }

    table {
        border-collapse: collapse;
        border-spacing: 0;
        width: 100%;
        border: 1px solid #ddd;
    }

    th, td {
        border: none;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even){background-color: #f2f2f2}
    tr:nth-child(odd){background-color: #e5eecc}


    body {
        background: url("../res/images/bus.png");
        background-size: 65%;
        background-repeat: no-repeat;
        background-attachment: fixed;
        background-position: center; 
    }
    #box {
        padding-top: 5px;
        background-color: #A9A9A9;
        line-height: 150%;
        font-weight: bold;
    }


	</style>
	<script src="../controller/UserHome.js"></script>
</head>
<body>

</body>
</html>




<?php

include("../model/dbconnection.php");

$code = $_REQUEST["q"];
$sql = "SELECT * FROM businfo WHERE code = '$code'";

echo "<br>";

$result = $conn->query($sql);

 echo "<div style='overflow-x:auto;'>";
 echo " <table id='BusRoute'>";
 echo "   <tr>";
 echo "<th>DEPARTING TIME</th>";
 echo "     <th>COACH NO</th>";
 echo "     <th>STARTING COUNTER</th>";
 echo "     <th>END COUNTER</th>";
 echo "     <th>FARE</th>";
 echo "     <th>ARRIVAL TIME</th>";
 echo "     <th>SEATS AVAILABLE</th>";
 echo "   </tr>";


while($data =  $result->fetch_assoc())
{   
    //echo $data['departing'];
    echo "<tr>";
    echo "<td align=center>".$data['departing']."</td>";
    echo "<td align=center>".$data['code']."</td>";
    echo "<td align=center>".$data['startcounter']."</td>";
    echo "<td align=center>".$data['endcounter']."</td>";
    echo "<td align=center>".$data['ticketfare']."</td>";
    echo "<td align=center>".$data['arival']."</td>";
    echo "<td align=center>".$data['seat']."</td>";
    echo "</tr>";
}
echo "</table>";
echo "</div>";

$conn->close();
?>


<?php
    
    echo "<div id= 'box'";
	echo "<br>";
	echo "<form method='POST' name = 'cnfr'>
    <center>
    <span>Bkash Number: 01911066421</span><br>
    <span>Trx ID:</span><br>
    <input type='text' name='trx' id='trx' required>
    <span class ='required'>*</span><br>
    <span>Enter Total Amount: </span><br>
    <input type='tk' name='tk' id='tk' required>
    <span class ='required'>*</span><br>
    <span>Enter Number Of Seat: </span><br>
    <input type='text' name='seat' id='seat' required>
    <span class ='required'>*</span><br>
    <input type='button' name='con' id='con' value ='Confirm' onclick = 'preConfirm(".$code.")'>
    </center>
    </form>";

	echo "<span id= 'report'></span>";
    echo "<br></div>";
?>



