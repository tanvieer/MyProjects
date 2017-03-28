<!DOCTYPE html>
<html>
<head>
	<title>Information OF Project</title>
	<style type="text/css">
		#nam {
			margin-left: 20%;
		}
		#info1 {
			margin-left: 3.5%;
		}
		#info2 {
			margin-left: 10.7%;
		}
		#info3 {
			margin-left: .9%;
		}
		#info4 {
			margin-left: 1%;
		}

		#owner {
			font-size: 150%;
			background-color: #90EE90;
			padding: 5px;
			margin-left: 20%;
			margin-right: 25%;
		}
		a {
			float: right;
			background-color: black;
			color: white;
			padding: 9px;
			text-decoration: none;
			margin-right: 15%;
			font-size: 150%;
		}

		a:hover{ 
		    color: black;
		    background-color: white;
		}

		body {
			background-color: #e5eecc;
			margin-left: 20%;
			margin-right: 20%;
		}
		ol {
			font-size: 120%;
		}
		b {
			color: red;
			font-size: 120%;
		}
	</style>
</head>
<body>
<br>
<br>
	<div id ="owner">
	<strong id = "nam">Name: </strong><span id = "info1"> Mohammad Tanvir Islam</span><br>
	<strong id = "nam">ID: </strong><span id = "info2"> 14-25471-1</span><br>
	<strong id = "nam">Section: </strong><span id = "info3"> [A]</span><br>
	<strong id = "nam">Course: </strong><span id = "info3"> WEB TECHNOLOGIES</span><br>
	</div>
	<hr>
	<br>
	<a href="./view/login.php">View Project</a>
	<div id = "projectinfo">
		<h2>There are 3 types of users.</h2>
		<ol>
		  <li>Super Admin User: [username: <b>superadmin</b> , password: <b>admin</b>] <ul>  
		  							<li>Can Make Normal User to Admin.</li> 
		  							<li>Can Make Admin to Normal User.</li> 
		  							<li>Can Delete User.</li> 
		  							<li>Can Add Route.</li>
		  							<li>Can Edit Route.</li>
		  							<li>Can Delete Route.</li> 
		  							<li>There Will Be Only One Super Admin. Pre Made by developer.</li> 
		  						</ul>
		  </li><br>
		  <li>Admin User:<ul>   
  							<li>Can Add Route.</li>
  							<li>Can Edit Route.</li>
  							<li>Can Delete Route.</li> 
  						</ul>
		  </li><br>

		  <li>Normal User: <ul>   
	  							<li>Can Search Route.</li>
	  							<li>Can Buy Ticket.</li>
	  						</ul>
		  </li><br>
		</ol>
	</div>

</body>
</html>