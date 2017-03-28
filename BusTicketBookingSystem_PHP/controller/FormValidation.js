var valid = 1;
var existEmail = "";
var existUname = "";

function shrt(id){
  return document.getElementById(id); 
}
function checknull(n){          
  var s=shrt(n).value;
  s = s.trim();
  if(s=="" || s==null || s==" ") return false;
  return true;
}

function reset(){   
  status=1; 
  shrt("fnamelbl").innerHTML="";
  shrt("fnamelbl").innerHTML="";
  shrt("emaillbl").innerHTML=""
  shrt("phnlbl").innerHTML="";
  
  shrt("passlbl").innerHTML="";
  shrt("cpasslbl").innerHTML="";
  shrt("unamelbl").innerHTML="";  

}




function names(){

  var regname=/^([A-Za-z\s]{1,}[\.\']{0,1}[A-Za-z\s]{0,})+$/;
  var fn=shrt("fname").value;
  var ln=shrt("lname").value;



  if(!checknull("fname")){ 
    shrt("fnamelbl").innerHTML="<br>First Name cannot be empty.<br>";
    status=0;
    return;
  }

  if(!regname.test(fn)){          
    shrt("fnamelbl").innerHTML="<br>Invalid first name.<br>"; 
    status=0;   
    return;           
  }

  if(!checknull("lname")){ 
    shrt("lnamelbl").innerHTML="<br>Last Name cannot be empty.<br>";
    status=0;
    return;
  }
  
  if(!regname.test(ln)){ 
    shrt("lnamelbl").innerHTML="<br>Invalid last name.<br>"; 
    status=0;               
    return;
  }
}

function phone(){
  if(!checknull("phone")){  
    shrt("phnlbl").innerHTML="<br>Phone Number cannot be empty.<br>"; 
    status=0; 
    return;
  }
  var regph=/^(0)(17|19|18|15|16)[0-9]{8}$/; 
  var val=shrt("phone").value;
  if(!regph.test(val)){           
    shrt("phnlbl").innerHTML="<br>Invalid phone number<br>"; 
    status=0; 
    return;           
  } 
}


function pass(){  
    if(!checknull("password")){
      shrt("passlbl").innerHTML="<br>Password cannot be empty.<br>";
      status=0; 
      return;
    }
    if(!checknull("cpassword")){
      shrt("cpasslbl").innerHTML="<br>Confirm password cannot be empty.<br>";
      status=0; 
      return;
    }
    if(shrt("password").value!=shrt("cpassword").value){       
      shrt("cpasslbl").innerHTML="<br>Passwords do not match<br>";  
      status=0;
      return;
    }
}



  function checkEmail(str) {   //          AJAX
    str = str.trim();
    //alert("mailstr="+str);
    var xhttp;
    if (str.length == 0) {
      shrt("emaillbl").innerHTML = "";
      return;
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
        existEmail = xhttp.responseText;
      }
    };
    xhttp.open("GET", "../model/emailcheckdb.php?q="+str, true);
    xhttp.send();

  }

  function checkexistemail(mail) {

    mail =  mail.trim();
    existEmail = existEmail.trim();

    // alert("given mail=" +mail);
    // alert("existEmail=" +existEmail);
    //alert("existEmail=" +existEmail+"/ "+(existEmail.indexOf(mail));                        what's wrong with this line !! :/


    if(existEmail == "" || existEmail == null) return;
    else if(existEmail.indexOf(mail)>=0) {
      shrt("emaillbl").innerHTML="<br>"+mail+" already registered.<br>";
      status = 0;
      return;
    }
  }



function email(){
  if(!checknull("email")){                    
    shrt("emaillbl").innerHTML="<br>Email cannot be empty.<br>";            
    status=0;                   
    return;
  }
  var regem=/[a-z.0-9]+@[a-z]+(.[a-z])+/;         
  var val=shrt("email").value;
  if(!regem.test(val)){                   
    shrt("emaillbl").innerHTML="<br>Invalid email address.<br>";            
    status=0;
    return;
  }
  checkexistemail(val);
}














function checkUsername(str) {   //reference from w3schools             AJAX
     
     str = str.trim();
      var xhttp;
    if (str.length == 0) {
      shrt("unamelbl").innerHTML = "";
      return;
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
        existUname = xhttp.responseText;
      }
    };
    xhttp.open("GET", "../model/gethint.php?q="+str, true);
    xhttp.send();
    }


function checkExistUname(unam) {
  unam =  unam.trim();
  existUname = existUname.trim();
  
  // alert("given=" +unam);
  // alert("existUname=" +existUname);

  if(existUname == "" || existUname == null) return;
  else if(unam==existUname) {
    shrt("unamelbl").innerHTML="<br>"+unam+" already registered.<br>";
    status = 0;
    return;
  }
}



function userid(){

  uid =shrt("username").value;
  

  if(!checknull("username")){ 
    shrt("unamelbl").innerHTML="<br>Username Name cannot be empty.<br>";
    status=0;
    return;
  }

  
  checkExistUname(uid);

}


function Validation(){
  reset();    
  userid();
  names();    
  phone();
  pass();
  email();
  
    
  if(status==0){  
    alert("ERROR! Please check the errors and try again.");
    return false;
  }
  return true;  
}






      function redirectRegistration(obj) { 
         window.location.href = "login.php";
      }