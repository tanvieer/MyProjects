using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DataLayer
{
    public class DbSeeder : DropCreateDatabaseIfModelChanges<UserDBContext>
    {
        protected override void Seed(UserDBContext context)
        {
            base.Seed(context);
            User users = new User()
            {
                Name = "Dokandar Shaheb",
                PhoneNumber = "01911066421",
              //  RegistrationDate = DateTime.UtcNow,
                EmployeeAddress = "Dhaka",
                Email = "tanvieer@gmail.com",
                Username = "user",
                Password = "user",
                ConfirmPassword = "user",
                Type = "Salesman"
            };
            context.Users.Add(users);

            User manager = new User()
            {
                Name = "Manager Shaheb",
                PhoneNumber = "01911066421",
               // RegistrationDate = DateTime.UtcNow,
                EmployeeAddress = "Dhaka",
                Email = "tanvieer@gmail.com",
                Username = "manager",
                Password = "manager",
                ConfirmPassword = "user",
                Type = "Manager"
            };
            context.Users.Add(manager);

            User admin = new User()
            {
                Name = "Admin Shaheb",
                PhoneNumber = "01911066421",
               // RegistrationDate = DateTime.UtcNow,
                EmployeeAddress = "Dhaka",
                Email = "tanvieer@gmail.com",
                Username = "admin",
                Password = "admin",
                ConfirmPassword = "admin",
                Type = "Admin"
            };
            context.Users.Add(admin);



            Inventory rice = new Inventory()
            {
                ProductName = "Rice",
                ProductBuyPrice = 79,
                ProductSellPrice = 85,
                ProductQuantity = 10

            };
            context.Inventories.Add(rice);


            Inventory alu = new Inventory()
            {
                ProductName = "Potato",
                ProductBuyPrice = 79,
                ProductSellPrice = 85,
                ProductQuantity = 10

            };
            context.Inventories.Add(alu);


            Inventory chips = new Inventory()
            {
                ProductName = "Chips",
                ProductBuyPrice = 12,
                ProductSellPrice = 15,
                ProductQuantity = 100

            };
            context.Inventories.Add(chips);

            context.SaveChanges();
        }
    }
}
