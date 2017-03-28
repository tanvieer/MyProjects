

function editroute(code){
	window.location.href = "../view/EditRouteDB.php?p="+code;
}
function refresh(){
    //alert("refresh");
    window.location.href ="../view/adminhome.php";
}

$(document).ready(function(){                          //edit route function update database
    $("#confirmedit").click(function(){
        var code = document.getElementById("cod").innerHTML.trim();   
        var seat = document.getElementById("seat").value.trim();
        var departing = document.getElementById("departing").value.trim();   
        var arival = document.getElementById("arival").value.trim();
        var ticketfare = document.getElementById("ticketfare").value.trim();    
        var startcounter = document.getElementById("startcounter").value.trim();      
        var endcounter = document.getElementById("endcounter").value.trim();    
        var available = document.getElementById("available").value.trim();  

        if (code.length == 0) { 
            document.getElementById("confirmMSG").innerHTML = "<br>";
        return;
        } else if (validateEdit()) {
            var xmlhttp;
                if (window.XMLHttpRequest) {
                // code for modern browsers
                 xmlhttp = new XMLHttpRequest();
                } else {
                // code for IE6, IE5
                 xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
              }
            xmlhttp.onreadystatechange = function() {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("confirmMSG").innerHTML = xmlhttp.responseText;
                }
            };
            xmlhttp.open("GET", "../model/editSubmitAjax.php?cd="+code+"&st="+seat +"&dp="+departing +"&ar="+arival +"&tf="+ticketfare +"&sc="+startcounter +"&ec="+endcounter +"&av="+available, true);
            xmlhttp.send();
        }
        else document.getElementById("confirmMSG").innerHTML = "Invalid Input!!"
    });
});




//========================================jquery  reference w3schools=========================================================


$(document).ready(function(){                     //add route
    $("#addroute").click(function(){
        $("#showdeleteroute").hide();
        $("#showeditroute").hide();
        $("#showdelconfirm").hide();
        $("#showaddconfirm").hide();
        $("#showaddroute").slideDown("slow");
    });
});


$(document).ready(function(){
        $("#deleteroute").click(function(){
        	$("#showaddroute").hide();
        	$("#showeditroute").hide();
            $("#showdelconfirm").hide();
            $("#showaddconfirm").hide();
            $("#showdeleteroute").slideDown(1000);
        });
    });

$(document).ready(function(){
        $("#editroute").click(function(){
        	$("#showaddroute").hide();
        	$("#showdeleteroute").hide();
            $("#showdelconfirm").hide();
            $("#showaddconfirm").hide();
            $("#showeditroute").slideDown(1000);
        });
    });




//========================================jquery  reference w3schools=========================================================






function deleteroute(code) {

    var r = confirm("Are you sure ? You want to delete COACH NO ="+code+" !!");

    if (code.length == 0 || r == false) { 
        return;
    } else {
        var xmlhttp;
            if (window.XMLHttpRequest) {
            // code for modern browsers
             xmlhttp = new XMLHttpRequest();
            } else {
            // code for IE6, IE5
             xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
          }



                xmlhttp.onreadystatechange = function() {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                $("#showdeleteroute").hide();
                 document.getElementById("showdelconfirm").innerHTML = xmlhttp.responseText;
                 $("#showdeleteroute").hide();
                 $("#showdelconfirm").slideDown("slow");
            }
        };
        xmlhttp.open("GET", "../model/deleteSubmitAjax.php?q=" + code, true);
        xmlhttp.send();
    }
}













//===========================================================add route validation=====================================
var status = 1;

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
    status = 1;
    shrt("deplbl").innerHTML= "";
    shrt("arivallbl").innerHTML="";
    shrt("farelbl").innerHTML="";
    shrt("seatlbl").innerHTML="";
    shrt("encounterlbl").innerHTML="";
}

function submitroute(){
    reset();
    var e = document.getElementById("available");
    var available = e.options[e.selectedIndex].value;

    var e = document.getElementById("stcounter");
    var stcounter = e.options[e.selectedIndex].value;

    var e = document.getElementById("encounter");
    var encounter = e.options[e.selectedIndex].value;

    var departing = shrt('departing').value.trim();
    var arival = shrt('arival').value.trim();
    var fare = shrt('fare').value.trim();
    var seat = shrt('seat').value.trim();

    if(!checknull('departing')) {
        shrt("deplbl").innerHTML="<br>Departing time cannot be empty!!";
        status = 0;
    }
    if(!checknull('arival')) {
        shrt("arivallbl").innerHTML="<br>Arival time cannot be empty!!";
        status = 0;
    }
    if(!checknull('fare')) {
        shrt("farelbl").innerHTML="<br>Ticket Fare cannot be empty!!";
        status = 0;
    }
    if(!checknull('seat')) {
        shrt("seatlbl").innerHTML="<br>Seat cannot be empty!!";
        status = 0;
    }
    if(stcounter == encounter) {
        shrt("encounterlbl").innerHTML="<br>Start Counter and End Counter cannot be same!!";
        status = 0;
    }

    if(status == 0) {
        return;
    }


    if(arival == departing){
        shrt("arivallbl").innerHTML="<br>Arival Time and Departing Time cannot be same!!";
        status = 0;
    }


    if(arival.indexOf(":") !=2 || (arival.length <5 || arival.length >5 )){
        shrt("arivallbl").innerHTML="<br>Invalid Arival Time.ex: time formate= 20:05";
        status = 0;
    }

    if(departing.indexOf(":") !=2 || (departing.length <5 || departing.length >5 )){
        shrt("deplbl").innerHTML="<br>Invalid Departing Time. ex: time formate= 14:05";
        status = 0;
    }

    if(seat > 40){
        shrt("seatlbl").innerHTML="<br>Number of seat should be less than or equal 40 !!";
        status = 0;
    }
    if(seat < 0){
        shrt("seatlbl").innerHTML="<br>Invalid Seat number!!";
        status = 0;
    }

    if(status == 1) {
        confirmSubmitroute(departing,arival,stcounter,encounter,seat,fare,available);
    }    
}

//===========================================================================================================




function confirmSubmitroute(departing,arival,startcounter,encounter,seat,fare,available){
    var xmlhttp;
    if (window.XMLHttpRequest) {
            // code for modern browsers
             xmlhttp = new XMLHttpRequest();
            } else {
            // code for IE6, IE5
             xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
          }
        xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            $("#showaddroute").hide();
             document.getElementById("showaddconfirm").innerHTML = xmlhttp.responseText;
             $("#showaddconfirm").slideDown("slow");
        }
    };

    var url = "../model/addSubmitAjax.php?dp="+departing+"&ar="+arival+"&sc="+startcounter+"&ec="+encounter+"&st="+seat+"&tf="+fare+"&av="+available;
    xmlhttp.open("GET", url, true);
    xmlhttp.send();

}




function validateEdit(){
    var code = document.getElementById("cod").innerHTML.trim();   
    var seat = document.getElementById("seat").value.trim();
    var departing = document.getElementById("departing").value.trim();   
    var arival = document.getElementById("arival").value.trim();
    var ticketfare = document.getElementById("ticketfare").value.trim();    
    var stcounter = document.getElementById("startcounter").value.trim();      
    var encounter = document.getElementById("endcounter").value.trim();    
    var available = document.getElementById("available").value.trim();


    if(!checknull('endcounter')) {
        alert("Departing time cannot be empty!!");
        return false;
    }
    if(!checknull('startcounter')) {
        alert("Departing time cannot be empty!!");
        return false;
    }

    if(available <0 ){
        alert("Invalid available Input [0 or 1]");
        return false;
    } 
    if(available >1 ) {
        alert("Invalid available Input [0 or 1]");
        return false;
    } 


    if(!checknull('available')) {
        //shrt("deplbl").innerHTML="<br>Departing time cannot be empty!!";
        alert("Please Insert Available field");
        return false;
    }

    if(!checknull('departing')) {
        //shrt("deplbl").innerHTML="<br>Departing time cannot be empty!!";
        alert("Please Insert Departing field");
        return false;
    }
    if(!checknull('arival')) {
        //shrt("arivallbl").innerHTML="<br>Arival time cannot be empty!!";
        alert("Please Insert Arival field");
        return false;
    }
    if(!checknull('ticketfare')) {
        //shrt("farelbl").innerHTML="<br>Ticket Fare cannot be empty!!";
        alert("Please Insert Ticket Fare field");
        return false;
    }
    if(!checknull('seat')) {
        //shrt("seatlbl").innerHTML="<br>Seat cannot be empty!!";
        alert("Please Insert Seat field");
        return false;
    }
    if(stcounter == encounter) {
        //shrt("encounterlbl").innerHTML="<br>Start Counter and End Counter cannot be same!!";
        alert("Start Counter and End Counter cannot be same!!");
        return false;
    }


    if(arival == departing){
        //shrt("arivallbl").innerHTML="<br>Arival Time and Departing Time cannot be same!!";
        alert("Arival time and Departing Time cannot be same!!");
        return false;
    }


    if(arival.indexOf(":") !=2 || (arival.length <5 || arival.length >5 )){
       // shrt("arivallbl").innerHTML="<br>Invalid Arival Time.ex: time formate= 20:05";
        alert("Invalid Arival Time.ex: time formate= 20:05!!");
        return false;
    }

    if(departing.indexOf(":") !=2 || (departing.length <5 || departing.length >5 )){
        //shrt("deplbl").innerHTML="<br>Invalid Departing Time. ex: time formate= 14:05";
        alert("Invalid Departing Time. ex: time formate= 14:05");
        return false;
    }

    if(seat > 40){
        alert("Number of seat should be less than or equal 40 !!");
        return false;
    }
    if(seat < 0){
        alert("Invalid Seat number!!");
        return false;
    }

    return true;
}