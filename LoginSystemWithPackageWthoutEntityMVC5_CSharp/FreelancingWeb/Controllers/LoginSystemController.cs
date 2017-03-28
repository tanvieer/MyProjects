using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem;

namespace FreelancingWeb.Controllers
{
    public class LoginSystemController : Controller
    {
        // GET: LoginSystem
        public ActionResult Index()
        {
            using (LoginDBContext context = new LoginDBContext())
            {
                return View(context.Users.ToList());
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User users)
        {
            string ty = Request["Type"].ToString();
            if (ModelState.IsValid)
            {
                using (LoginDBContext db = new LoginDBContext())
                {


                    var obj = db.Users.Where(a => a.Email.Equals(users.Email)).FirstOrDefault();
                    var objusername = db.Users.Where(a => a.Username.Equals(users.Username)).FirstOrDefault();
                    if (obj == null && objusername== null)
                    {
                        users.Type = ty;
                        db.Users.Add(users);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Login");
                    }
                    
                    else if (obj != null)
                    {
                        ModelState.AddModelError("", users.Email.ToString() + " Already Registered.");
                        return View(users);
                    }
                    else if (objusername != null)
                    {
                        ModelState.AddModelError("", users.Username.ToString() + " Username not available.");
                        return View(users);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something Wrong Please Try Again Latter.");
                        return View(users);
                    }
                }
                

            }

            else
            {
                return View(users);
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User objUser)
        {
            using (LoginDBContext db = new LoginDBContext())
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
                        if (type.Equals("Employee")) return RedirectToAction("Employee", "FolderName");
                        else if (type.Equals("Employer")) return RedirectToAction("Employer", "FolderName");
                        else if (type.Equals("Both")) return RedirectToAction("Both", "FolderName");
                        else
                        {
                            ModelState.AddModelError("", "User Type invalid, please contact with us.");
                            return RedirectToAction("Login");
                        }
                    }
                    catch
                    {
                       
                        ModelState.AddModelError("", "Something Wrong Please Try Again Latter.");
                        return View(objUser);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View(objUser);
                }
            }
        }


















        public ActionResult LogOff()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}