
var c_time = "";
var same = 5;

function timeCompare(date){
	var current_date = new Date().toISOString();
	var current_time = new Date().toTimeString();

	current_date = current_date.substring(0, 10);
	date = date.substring(0, 10);

	same = date.localeCompare(current_date);

  	c_time = current_time.substring(0, 5).toString(); 
}

function showTable() {
	if(document.getElementById("date").value != ""){
		var d1 = new Date(document.getElementById("date").value).toISOString();
		//document.getElementById("txtHint").innerHTML = d1;
		timeCompare(d1);

		if(same <0) 
			{
				document.getElementById("datereq").innerHTML = "* Please Select Valid Date!";
				document.getElementById("txtHint").innerHTML = "";
				return false;
			}
	}
		else {	
			document.getElementById("datereq").innerHTML = "* Please Select Date!";
			document.searchform.date.focus();
			document.getElementById("txtHint").innerHTML = "";
			return false;
		}


	var leave =  document.getElementById("search_leavingform").value.trim();
	var str = document.getElementById("search_goingto").value.trim();
	document.getElementById("datereq").innerHTML = "*";

	  var xhttp; 
	  if (str == "") {
	    document.getElementById("txtHint").innerHTML = "";
	    return false;
	  }



	  if (window.XMLHttpRequest) {
	    // code for modern browsers
	   	xhttp = new XMLHttpRequest();
	    } else {
	    // code for IE6, IE5
	    xhttp = new ActiveXObject("Microsoft.XMLHTTP");
	  }
	  xhttp.onreadystatechange = function() {
	    if (xhttp.readyState == 4 && xhttp.status == 200) {
	    document.getElementById("txtHint").innerHTML = xhttp.responseText;
	    }
	  };
	  if(same>0){
	  	xhttp.open("GET", "../model/getroute.php?q="+leave+"&p="+str+"&t=0", true);
	  } else xhttp.open("GET", "../model/getroute.php?q="+leave+"&p="+str+"&t="+c_time, true);
	  

	  xhttp.send();
	
	  return true;
}



function confirmTicket (code,num_seat) {
	 var xhttp; 
	  if (window.XMLHttpRequest) {
    // code for modern browsers
    xhttp = new XMLHttpRequest();
    } else {
    // code for IE6, IE5
    xhttp = new ActiveXObject("Microsoft.XMLHTTP");
  }
	  xhttp.onreadystatechange = function() {
	    if (xhttp.readyState == 4 && xhttp.status == 200) {
	    	document.getElementById("report").innerHTML = xhttp.responseText;
	    }
	  };


	  xhttp.open("GET", "../model/businfoajax.php?q="+code+"&st="+num_seat, true);
	 

	  xhttp.send();
}




function selectButton(code){

	window.location.href = "../view/buypage.php?q="+code;

}


function preConfirm(code){
	var amount = document.getElementById("tk").value;
	var req_seat =document.getElementById("seat").value;
	var trx = document.getElementById("trx").value;

	if(req_seat*450 == amount && req_seat > 0){

		document.getElementById("report").innerHTML = "";
		confirmTicket(code,req_seat);
	}
	else if(req_seat*450 != amount && req_seat*450 >0) {
		document.getElementById("report").innerHTML = "Please Enter Valid Amount. Suggested Amount is: "+(req_seat*450);
		return false;
	}
	else {
		document.getElementById("report").innerHTML = "Please fillup all.";
		return false;
	}

	
}
