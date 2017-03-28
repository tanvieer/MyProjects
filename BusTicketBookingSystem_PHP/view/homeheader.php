 <?php
	include('./../controller/VerifySession.php');
	if( !ifCredentialSaved() ) {
		header("Location: ./../controller/logout.php");
	}
    if($_SESSION['admin']==1)	header("Location: adminhome.php");
    if($_SESSION['admin']==3)	header("Location: adminhome.php");
	//print_r( getSession() ); 
?>

<!DOCTYPE html>
<html>
<head>
	<style type="text/css">
			
		#nam {
		    text-transform: uppercase;
		    font-weight: bold;
	    }


	    ul {
	    	list-style-type: none;
		}
		.required {
			color: red;
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

	    .userhome{
	    	background-color: #A9A9A9;
			color: black;
	    }
	    #hm {
	    	float: left;
	    	margin-left: 10px ;
	    	margin-top: 15px;
	    	margin-bottom: 25px;
	    }

	</style>
</head>
<body>
	<div class="userhome">
		<a href="./home.php" id = "hm">HOME</a>
		<span>Welcome  <span id ="nam"><?php echo $_SESSION['dfname']." ".$_SESSION['dlname'];?>  </span></span><br><a href="../controller/logout.php"> Log Out </a>
		<br><a href="./registration.php">CREATE AN ACCOUNT</a>
		<br><br>
	</div>
</body>
</html>