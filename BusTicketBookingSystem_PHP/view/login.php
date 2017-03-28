<?php
	include("univarsalheader.php");
?>

<?php
$Err = "";
$Srr = "";
$uvalu = "";
$passvalu = "";
$headers = apache_request_headers();



	if(!isset($_COOKIE['success'])) {
	    $Srr = "";
	} else if ($_COOKIE['success'] !="") {
	     $Srr = "Username <strong>".$_COOKIE['success']."</strong> successfully registered.<br>";
	     $uvalu = $_COOKIE['success'];
	     $passvalu = $_COOKIE['pass'];
	     setcookie('success', '', time() - 3600, '/');
	     setcookie('pass', '', time() - 3600, '/');

	}

	if(isset( $headers["Referer"] )){
		if($headers["Referer"] == "http://localhost/Webtechfinal/view/login.php"){
			$Err = "Password Not Matched!! Try Again!!<br>";
    		$headers["Referer"] = null;
		}
    	
	}
	
	include("../controller/VerifySession.php");
	if ( ifCredentialSaved() &&  $_SESSION['admin'] ==3 ) {
			header("Location: manageAdmin.php");
	}
	else if( ifCredentialSaved() && $_SESSION['admin']==0 ) {
		header("Location: home.php");
	}
	else if ( ifCredentialSaved() &&  $_SESSION['admin'] ==1 ) {
		header("Location: adminhome.php");
	} 
?>

<!DOCTYPE html>
<html>
<head>
	<title>Login Page</title>
	
	<style rel="stylesheet">
	#main_container {
		text-align: center;
		background-color: #A9A9A9;
        line-height: 200%;
        margin-left: 25%;
        margin-right: 25%;
        padding: 5px;
	}

	.error {
		color: #FF0000;
		font-size: 25px;
	}
	.srror {
		background-color: #87CEFA;
		color: black;
		font-size: 25px;
	}

	body {
    	background: url("../res/images/bus.png");
    	background-size: 65%;
    	background-repeat: no-repeat;
    	background-attachment: fixed;
    	background-position: center; 
	}
	</style>

	<script src="../controller/validation.js"></script>
</head>

<body>
<div id="main_container">
<form name="myForm" method="POST" action="../controller/process.php" onsubmit="return validateForm()">
	<div>
	<span class="error"><?php echo $Err; $Err = "";?></span> 
	<span class="srror"><?php echo $Srr; $Srr = "";?></span> 
		<span>Username:</span>
		<input type="text" name="username" required value= <?php echo $uvalu;?>  >
	</div>
	<div>
		<span>Password:</span>
		<input type="password" name="password" required value= <?php echo $passvalu;?>  >
	</div>
	<div>
		<input type="submit" value="Sign In" onclick="return validateForm()">
		<input type="button" value="Registration" onclick="redirectRegistration(this)" >
	</div>
</form>
</div>
</body>
</html>