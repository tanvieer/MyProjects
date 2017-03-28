
<!DOCTYPE html>
<html>
<head>
	<title>ADMIN Edit Page</title>
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
    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../controller/adminhome.js"></script>

</head>
<body>

<?php

include("../model/dbconnection.php");


$conn = new mysqli($servername, $username, $password, $dbname);


$sql = "SELECT * FROM businfo ";



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
 echo "     <th>AVAILABLE</th>";
 echo "     <th>SELECT BUTTON</th>";
 echo "   </tr>";

$empty = true;

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
    echo "<td align=center>".$data['avaiable']."</td>";
    echo "<td align=center>"."<button type='button' class = 'btn' id='editid' onclick ='editroute(".$data['code'].")'>Edit</button>"."</td>";
    echo "</tr>";
}
echo "</table>";
echo "</div>";

$conn->close();
?>


</body>
</html>