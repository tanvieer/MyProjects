 <?php
	

		$servername = "localhost";
		$susername = "root";
		$spassword = "";
		$db = "login";
		$table ="users";
		
		$link = mysql_connect($servername,$susername ,$spassword);
		mysql_select_db($db);




		$uname = $_POST['username'];
		$pass = $_POST['password'];
		
		$qry = "SELECT * FROM ".$table." where username = '$uname' and password = '$pass'";
		$result = mysql_query($qry) or die ("failed to query from db.php line 20");
		$row = mysql_fetch_array($result);


	    	if( $row["username"] == $uname &&  $row["password"] == $pass){

	    		$dusername = $row["username"];
				$dpassword = $row["password"];
				$dadmin = $row["admin"];
	    	}

	 mysql_close($link );	  



	 $servername = "localhost";
		$susername = "root";
		$spassword = "";
		$db = "login";
		$table ="userinfo";
		
		$link = mysql_connect($servername,$susername ,$spassword);
		mysql_select_db($db);  	


		$qry = "SELECT * FROM ".$table." where username = '$uname'";
		$result = mysql_query($qry) or die ("failed to query from db.php line 20");
		$row = mysql_fetch_array($result);

		$dfname = $row["first_name"];
		$dlname = $row["last_name"];

	 mysql_close($link);	
?> 