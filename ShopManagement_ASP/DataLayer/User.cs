using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace DataLayer
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

       // [ScaffoldColumn(false)]
        //[Timestamp]
       // public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Employee Address")]
        public string EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email appears to be invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
       // [Compare("Password", ErrorMessage = "Email Should Match")]
       // [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        

        
        public string Type { get; set; }






    }
}
