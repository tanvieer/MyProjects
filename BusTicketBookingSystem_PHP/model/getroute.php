<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "login";

$s_counter = $_REQUEST["q"];
$e_counter = $_REQUEST["p"];
$tim = $_REQUEST["t"];

if($tim!=0) {
    echo "Current Time: ".$tim;
}

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
if($tim!=0) {
    $sql = "SELECT * FROM businfo WHERE avaiable = '1' AND startcounter = '$s_counter' AND endcounter = '$e_counter' AND departing NOT BETWEEN '00:00' AND '$tim'";
}
else $sql = "SELECT * FROM businfo where avaiable = '1' AND startcounter = '$s_counter' AND endcounter = '$e_counter'";



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
    echo "<td align=center>"."<button type='button' id='".$data['code']."'      onclick ='selectButton(".$data['code'].")''       >Select</button>"."</td>";
    echo "</tr>";
    $empty = false;
}
echo "</table>";
echo "</div>";


if ($empty) echo "<br><h2 style='color:red;'>No route found!!</h2>";


$conn->close();
?>