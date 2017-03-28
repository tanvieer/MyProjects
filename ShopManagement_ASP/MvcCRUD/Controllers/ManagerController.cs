using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class ManagerController : Controller
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
                if (type.Equals("Salesman")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }


            return View();
        }

    }
}
