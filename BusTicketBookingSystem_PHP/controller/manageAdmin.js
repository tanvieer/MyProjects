function makeadmin(username) {


    var r = confirm("Are you sure ? You want to Make Admin User = "+username+" !!");

    if (username.length == 0 || r == false) { 
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
                 alert(xmlhttp.responseText);
                 window.location.href = "../view/manageAdmin.php";
            }
        };
        xmlhttp.open("POST", "../model/manageAdminDB.php?uname="+username+"&action=1", true);
        xmlhttp.send();
    }
}

function makeuser(username) {

    var r = confirm("Are you sure ? You want to Make User User = "+username+" !!");

    if (username.length == 0 || r == false) { 
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
                 alert(xmlhttp.responseText);

                 window.location.href = "../view/manageAdmin.php";
            }
        };
        xmlhttp.open("POST", "../model/manageAdminDB.php?uname="+username+"&action=2", true);
        xmlhttp.send();
    }
}


function deleteuser(username) {
    var r = confirm("Are you sure ? You want to delete User = "+username+" !!");

    if (username.length == 0 || r == false) { 
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
                 alert(xmlhttp.responseText);

                 window.location.href = "../view/manageAdmin.php";
            }
        };
        xmlhttp.open("POST", "../model/manageAdminDB.php?uname="+username+"&action=3", true);
        xmlhttp.send();
    }
}

