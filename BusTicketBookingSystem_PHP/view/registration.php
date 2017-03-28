<?php
	include("univarsalheader.php");
?>
<!DOCTYPE html>
<html>
<head>
	<title>Registration Page</title>
	
	<style rel="stylesheet">
	#main_container {
		text-align: center;
		background-color: #A9A9A9;
        line-height: 150%;
        margin-left: 30%;
        margin-right: 30%;
	}

	body {
    	background: url("../res/images/bus.png");
    	background-size: 65%;
    	background-repeat: no-repeat;
    	background-attachment: fixed;
    	background-position: center; 
	}
	.error {
		color: red;
	}


	</style>
	
	<script src="../controller/FormValidation.js"></script>

</head>
<body>
<div id="main_container"><br>
<form name ="myForm" method="POST" action="../controller/regprocess.php" onsubmit= "return Validation()">
	<div>
		<span>First Name:</span><br>
		<input type="text" name= "fname"  id="fname" value=""/>
		<small class='error' id='fnamelbl'><br></small>
	</div>
	<div>
		<span>Last Name:</span><br>
		<input type="text" name="lname" id="lname" value=""/>
		<small class='error' id='lnamelbl'><br></small>
	</div>


	<div>
		<span>Email:</span><br>
		<input type="text" name="email" id="email" value="" onblur = "checkEmail(this.value)"/>
		<small class='error' id='emaillbl'><br></small>
	</div> 




	<div>
		<span>Your Username:</span><br>
		<input type="text" name="username" id="username" value=""  onblur ="checkUsername(this.value)"/>
		<small class='error' id='unamelbl'><br></small>
	</div>



	<div>
		<span>Your Password:</span><br>
		<input type="password" name="password" id="password"  value="" />
		<small class='error' id='passlbl'><br></small>
	</div>


	<div>
		<span>Confirm Password:</span><br>
		<input type="password" name="cpassword" id="cpassword"  value=""/>
		<small class='error' id='cpasslbl'><br></small>
	</div>



	<div>
		<span>Phone Number:</span><br>
		<input type="text" name="phone" id="phone" value="" />
		<small class='error' id='phnlbl'><br></small>
	</div>

	<div>
		<input type="submit" value="Register"/>
		<input type="button" value="Back To Login" onclick ="redirectRegistration(this)" />
	</div>
</form><br>
</div>
</body>
</html>