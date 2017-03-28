
<?php
    //include('./../controller/VerifySession.php');
    
    // if( !ifCredentialSaved()) {
    //     header("Location: ./../controller/logout.php");
    // }

    // if( $_SESSION['admin']==0) {
    //     header("Location: ./../view/login.php");
    // } 
    
?>



<!DOCTYPE html>
<html>
<head>
	<title>ADMIN Edit Page</title>
     <style type="text/css">

        .head {
            background-color: #A9A9A9;
            color: black;
        }
        #nam {
            text-transform: uppercase;
            font-weight: bold;
        }
        #adr {
            font-weight: bold;
            text-align: center;
            line-height: 150%;
        }
        input {
            text-align: center;
            width: 10%;
        }
        select {
            width: 10%;
        }
        .error {
          color : red;
        }
    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../controller/adminhome.js"></script>

</head>
<body>
    <div id = "adr">
        <br>
        <span>Start Counter: </span><br>
        <select id="stcounter">
          <option value="Dhaka">Dhaka</option>
          <option value="Rajshahi">Rajshahi</option>
          <option value="Sylhet">Sylhet</option>
          <option value="Jessore">Jessore</option>
          <option value="Khulna">Khulna</option>
          <option value="Chittagong">Chittagong</option>
        </select>

        <br>
        <span>End Counter: </span><br>
        <select id="encounter">
          <option value="Rajshahi">Rajshahi</option>
          <option value="Dhaka">Dhaka</option>
          <option value="Sylhet">Sylhet</option>
          <option value="Jessore">Jessore</option>
          <option value="Khulna">Khulna</option>
          <option value="Chittagong">Chittagong</option>
        </select>
        <small class="error" id = "encounterlbl"></small>

        <br><span>Departing Time: </span><br>
        <input type="text" name="departing" id ="departing" placeholder="00:00">
        <small class="error" id = "deplbl"></small>

        <br><span>Arival Time: </span><br>
        <input type="text" name="arival" id ="arival" placeholder="00:00">
        <small class="error" id = "arivallbl"></small>

        <br><span>Ticket Fare: </span><br>
        <input type="text" name="fare" id ="fare" >
        <small class="error" id = "farelbl"></small>

        <br><span>Seat:</span><br>
        <input type="text" name="seat" id ="seat" placeholder="30">
        <small class="error" id = "seatlbl"></small>

        <br><span>Available: </span><br>
        <select id="available">
          <option value="1">YES</option>
          <option value="0">NO</option>
        </select><br>

        <input type="button" name="submitaddroute" id ="submitaddroute" onclick="submitroute()" value ="Submit">

        </div>
</body>
</html>