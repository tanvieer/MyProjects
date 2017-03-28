using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
      
        public ActionResult AdminHome()
        {
            using (UserDBContext context = new UserDBContext())
            {
                return View(context.Users.ToList());
            }
        }


        
        public ActionResult Login()
        {
            try
            {
                string type = Session["Type"].ToString();
                if (type.Equals("Admin")) return RedirectToAction("Index", "Admin");
                else if (type.Equals("Manager")) return RedirectToAction("Index", "Manager");
                else if (type.Equals("Salesman")) return RedirectToAction("Create", "Sales");
                else return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
           
                using (UserDBContext db = new UserDBContext())
                {
                    var obj = db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Type"] = obj.Type.ToString();
                        Session["Name"] = obj.Name.ToString();

                        try
                        {
                          
                            string type = Session["Type"].ToString();
                            if (type.Equals("Admin")) return RedirectToAction("Index", "Admin");
                            else if (type.Equals("Manager")) return RedirectToAction("Index", "Manager");
                            else if (type.Equals("Salesman")) return RedirectToAction("Create", "Sales");
                            else return RedirectToAction("Login");
                        }
                        catch
                        {
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        return View(objUser);
                    }
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
                    db.Users.Add(users);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("AdminHome");

            }

            else
            {
                return View(users);
            }
        }
        public ActionResult LogOff()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }


    }
}
