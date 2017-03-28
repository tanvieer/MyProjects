<?php
    include("univarsalheader.php");
?>
<?php
    include('./../view/homeheader.php');
?>

<!DOCTYPE html>
<html>
<head>

<title>Bus Ticket</title>

	<style rel="stylesheet">
    .required {
        color: red;
    }

    body {
        text-align: center;
        background: url("../res/images/bus.png");
        background-size: 40%;
        background-repeat: no-repeat;
        background-attachment: fixed;
        background-position: center; 
    }
    .userhome1{
            background-color: #A9A9A9;
            color: black;
            padding: 2px;
            word-spacing: 1px;
            line-height: 25px;
        }

	</style>

    <script src="../controller/UserHome.js"></script>



</head>

<body>
 	
    <div class="userhome1">
    
        <form name="searchform">
            Leaving From:
                <select name="search_leavingform" id="search_leavingform" class="select">

                	<option value="Dhaka" label="Dhaka">Dhaka</option>
                    <option value="Rajshahi" label="Rajshahi">Rajshahi</option>
                    <option value="Chittagong" label="Chittagong">Chittagong</option>
                    <option value="Sylhet" label="Sylhet">Sylhet</option>
                    <option value="Khulna" label="Khulna">Khulna</option>
                    <option value="Jessore" label="Jessore">Jessore</option>
                </select>
                <span class="required">*</span>
            
            <br>
            Going To:
                <select name="search_goingto" id="search_goingto" class="select">

                    <option value="Rajshahi" label="Rajshahi">Rajshahi</option>
                	<option value="Dhaka" label="Dhaka">Dhaka</option>
                    <option value="Chittagong" label="Chittagong">Chittagong</option>
                    <option value="Sylhet" label="Sylhet">Sylhet</option>
                    <option value="Khulna" label="Khulna">Khulna</option>
                    <option value="Jessore" label="Jessore">Jessore</option>
                </select> 
                <span class="required">*</span>
             <br>
            Departing On:
            <input type="date" id="date" name = "date"/>
            <span class="required" id="datereq">*</span>
            <br>                                                                                                         
            <button type="button" id='search_submit' name='search_submit' onclick = "return showTable()">Search</button>

    	</form>
    </div>
<hr>
<div id="txtHint"><b></b></div>

</body>
</html>
