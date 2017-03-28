using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class AdminController : Controller
    {


        public ActionResult Index()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }

            return View();
        }



        public ActionResult MyChart()
        {

            decimal Jan = 0;
            decimal Feb = 0;
            decimal Mar = 0;
            decimal Apr = 0;
            decimal May = 0;
            decimal Jun = 0;
            decimal Jul = 0;
            decimal Aug = 0;
            decimal Sep = 0;
            decimal Oct = 0;
            decimal Nov = 0;
            decimal Dec = 0;


            using (UserDBContext context = new UserDBContext())
            {
                List<SalesReport> sale = context.SalesReports.ToList();
                foreach (SalesReport item in sale)
                {
                    int m = item.SaleDate.Month;
                    if (m == 1) Jan += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 2) Feb += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 3) Mar += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 4) Apr += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 5) May += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 6) Jun += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 7) Jul += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 8) Aug += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 9) Sep += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 10) Oct += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 11) Nov += Convert.ToDecimal(item.ProductPrice);
                    else if (m == 12) Dec += Convert.ToDecimal(item.ProductPrice);
                }

            }





            

            new Chart(width: 1000, height: 200)
            .AddSeries(
            chartType: "column",
            xValue: new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
            yValues: new[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }
            ).Write("png");
            return null;
        }

        public ActionResult ManageEmployee()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }


            using (UserDBContext context = new UserDBContext())
            {
                return View(context.Users.ToList());
            }
        
        }

        [HttpGet]
        public ActionResult Create()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }


            return View();

        }

        [HttpPost]
        public ActionResult Create(User users)
        {
            string ty = Request["Type"].ToString();

            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }





            if (ModelState.IsValid)
            {

                using (UserDBContext db = new UserDBContext())
                {
                    users.Type = ty;
                    db.Users.Add(users);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("ManageEmployee");

            }

            else
            {
                return View(users);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {


            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }




            using (UserDBContext context = new UserDBContext())
            {
                User user = context.Users.SingleOrDefault(d => d.UserId == id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            string ty = Request["Type"].ToString();

            using (UserDBContext context = new UserDBContext())
            {
                User userUpdate = context.Users.SingleOrDefault(d => d.UserId == user.UserId);
                userUpdate.Name = user.Name;
                userUpdate.PhoneNumber = user.PhoneNumber;
                userUpdate.EmployeeAddress = user.EmployeeAddress;
                userUpdate.Email = user.Email;
                userUpdate.Username = user.Username;
                userUpdate.Type = ty;

                context.SaveChanges();
            }
            return RedirectToAction("ManageEmployee");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }



            using (UserDBContext context = new UserDBContext())
            {
                User user = context.Users.SingleOrDefault(d => d.UserId == id);
                return View(user);
            }
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {


            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            try
            {
                string type = Session["Type"].ToString();
                if (!type.Equals("Admin")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }



            using (UserDBContext context = new UserDBContext())
            {
                User user = context.Users.SingleOrDefault(d => d.UserId == id);
                return View(user);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            using (UserDBContext context = new UserDBContext())
            {
                User user = context.Users.SingleOrDefault(d => d.UserId == id);
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("ManageEmployee");
        }



    }
}
