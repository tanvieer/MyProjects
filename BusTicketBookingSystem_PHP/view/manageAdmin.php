<?php
// $headers = apache_request_headers();
	// if(!isset( $headers["Referer"] )){
	// 	die("Directory access is forbidden.");
	// }

	 include('./../controller/VerifySession.php');
	if( !ifCredentialSaved() ) {
		
		header("Location: ./../controller/logout.php");
	}

	if(ifCredentialSaved()){
		if($_SESSION['admin'] != 3){
			header("Location: ./../controller/logout.php");
		}
	}


$manager = "hide";
$ad = " ADMIN ";

	if($_SESSION['admin']==3) {
		$manager = "";
		$ad = " SUPER ADMIN ";
	}

	
?>


<!DOCTYPE html>
<html>
<head>
	<title>Admin Manage</title>

	<link rel="stylesheet" type="text/css" href="../view/styletable.css">
	<script src="../controller/manageAdmin.js"></script>

</head>
<body>
	<div class = "head">
	<br>
		<a href="./adminhome.php" id = "hm">HOME</a>

		<center><span>Welcome <?php echo $ad ?> <span id ="nam"><?php echo $_SESSION['dlname'];?>  </span>	</span>
		<a href="../controller/logout.php">Log Out</a></center>
		<a href="../view/manageAdmin.php" id = "rf">Refresh Database</a>
	<br>
	</div>
	<hr>


<?php
	
	include("../model/dbconnection.php");

	   $sql = "SELECT * FROM users WHERE admin != 3";

	   $result = $conn->query($sql);



		 echo "<div style='overflow-x:auto;'>";
		 echo " 	<table id='userlist'>";
		 echo "   <tr>";
		 echo "     <th>User NO</th>";
		 echo "     <th>Username</th>";
		 echo "     <th>Password</th>";
		 echo "     <th>Admin Status</th>";
		 echo "     <th>Make Admin</th>";
		 echo "     <th>Make Normal User</th>";
		 echo "     <th>Delete User</th>";
 		 echo "   </tr>";




	$empty = true;
	$count = 1;
	if ($result->num_rows > 0) {
    	while($data = $result->fetch_assoc()) 
		{   
		    echo "<tr>";
		    echo "<td align=center>".$count++."</td>";
		    echo "<td align=center>".$data['username']."</td>";
		    echo "<td align=center>".$data['password']."</td>";

		    echo "<td align=center>".$data['admin']."</td>";


		    echo "<td align=center>"."<button type='button' onclick =\"makeadmin('".$data['username']."')\"  >Make Admin</button>"."</td>";
		    echo "<td align=center>"."<button type='button' onclick =\"makeuser('".$data['username']."')\" >Make Normal User</button>"."</td>";
		    echo "<td align=center>"."<button type='button' onclick =\"deleteuser('".$data['username']."')\" >Delete User</button>"."</td>";

		    echo "</tr>";
		    $empty = false;
		}
		echo "</table>";
		echo "</div>";

		if ($empty) echo "<br><h2 style='color:red;'>User list Empty!!</h2>";
	}

	$conn->close();

?>


















</body>
</html>

