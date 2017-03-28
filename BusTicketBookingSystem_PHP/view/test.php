<!DOCTYPE html>
<html>
<body>

<?php 
echo $_SERVER['PHP_SELF'];
echo "<br>";
echo $_SERVER['SERVER_NAME'];
echo "<br>";
echo $_SERVER['HTTP_HOST'];
echo "<br>";
echo $_SERVER['HTTP_REFERER'];
echo "<br>";
echo $_SERVER['HTTP_USER_AGENT'];
echo "<br>";
echo $_SERVER['SCRIPT_NAME'];

$var = 12;
//echo strlen($var);
if( !isset($_SESSION) ) {
		session_start();
	}
	//print_r($_SESSION);

?>


</body>
</html>