     var test = "     ";

      function redirectRegistration(obj) { 
         window.location.href = "registration.php";
      }

      function validateForm() {
      
      var x = document.forms["myForm"]["username"].value;
       if (x == null || x == "" ||  x.trim() == test.trim()) {
           alert("Name must be filled out");
           return false;
      }
      var y = document.forms["myForm"]["password"].value;
         if (y == null || y == "" ||  y.trim() == test.trim()) {
            alert("Password must be filled out");
            return false;
         }
      }

      function validateRegUname(){
        var x = document.forms["myForm"]["username"].value;
        if (x == null || x == "" || x.trim() == test.trim()) {
            alert("User Name must be filled out");
            document.myForm.username.focus();
          return false;
        }
      return true;
      }

      function validateRegPassword(){
        var x = document.forms["myForm"]["password"].value;
        if (x == null || x == "" || x.trim() == test.trim()) {
            alert("Password must be filled out");
            document.myForm.password.focus();
          return false;
        }
      return true;
      }


