<?php
	if( !isset($_SESSION) ) {
		session_start();
	}
	
	function ifCredentialSaved() {
		if( !isset( $_SESSION['uname'] )
			|| !isset( $_SESSION['upass'] )
			|| $_SESSION['uname'] == "" 
			|| $_SESSION['upass'] == "" ) {
				return false;
		}
		return true;
	}
	
	function verify($uname, $upass ) {
		if( $_SESSION['uname'] == $uname && $_SESSION['upass'] == $upass ) {
				return true;
		}
		
		return false;
	}
	
	function saveCredentials($uname, $upass , $dfname , $dlname ,$damin) {
		$_SESSION['uname'] = $uname;
		$_SESSION['upass'] = $upass;
		$_SESSION['dfname'] =$dfname;
		$_SESSION['dlname'] =$dlname;
		$_SESSION['admin'] = $damin;
	}
	
	function getSession() {
		return $_SESSION;
	}
?>