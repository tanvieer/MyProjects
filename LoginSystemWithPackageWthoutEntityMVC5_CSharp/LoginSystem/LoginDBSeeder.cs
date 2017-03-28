using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    public class LoginDBSeeder : DropCreateDatabaseIfModelChanges<LoginDBContext>
    {
        protected override void Seed(LoginDBContext context)
        {
            base.Seed(context);
            User users = new User()
            {
                Name = "Tanvir Islam",
                //  RegistrationDate = DateTime.UtcNow,
                Country = "Bangladesh",
                Email = "tanvieer@gmail.com",
                Username = "tanvir",
                Password = "tanvir",
                ConfirmPassword = "tanvir",
                Type = "Employee"
            };
            context.Users.Add(users);

            users = new User()
            {
                Name = "Syeda Nuzhat Sabrina",
                //  RegistrationDate = DateTime.UtcNow,
                Country = "Bangladesh",
                Email = "snuzhatsabrina@gmail.com",
                Username = "nabila",
                Password = "nabila",
                ConfirmPassword = "nabila",
                Type = "Employer"
            };
            context.Users.Add(users);
           

            context.SaveChanges();
        }
    }
}
