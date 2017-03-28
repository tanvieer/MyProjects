<?php
	include('./../controller/VerifySession.php');
	
	if( !ifCredentialSaved()) {
		header("Location: ./../controller/logout.php");
	}

	if( $_SESSION['admin']==0) {
		header("Location: ./../view/login.php");
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
	<title>ADMIN</title>
	

	<link rel="stylesheet" type="text/css" href="../view/styletable.css">


	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	<script src="../controller/adminhome.js"></script>


</head>

<body >
	<div class = "head">
	<br>
		<a href="./adminhome.php" id = "hm">HOME</a>
		<a class = "<?php echo $manager ?>" href="../view/manageAdmin.php" id = "hm">Manage Admin</a>

		<center><span>Welcome <?php echo $ad ?> <span id ="nam"><?php echo $_SESSION['dlname'];?>  </span>	</span><a href="../controller/logout.php">Log Out</a></center>
		<a href="./adminhome.php" id = "rf">Refresh Database</a>
	<br>
	</div>
	<hr>
	 <center id = "head1"> 
	 <input type="button" class="btn" name="editroute" id="editroute" value="VIEW ROUTE" > 
	 <input type="button" class="btn" name="addroute" id="addroute" value="ADD ROUTE"> 
	 <input type="button" class="btn" name="deleteroute" id="deleteroute" value="DELETE ROUTE" >
	</center>
	<hr>

	<div id="showaddroute" class = "panel"> <?php include("../view/addroute.php")?></div>

	<div id="showdeleteroute" class = "panel">
	<?php 
		include("../view/deleteRoute.php");
	?>
	</div>

	<div id="showeditroute" class = "panel">
	<?php 
		include("../view/EditRoute.php");
	?>
	</div>

	<h2 class = "panel" id = "showdelconfirm"> </h2>
	<h2 class = "panel" id = "showaddconfirm"> </h2>


</body>
</html>