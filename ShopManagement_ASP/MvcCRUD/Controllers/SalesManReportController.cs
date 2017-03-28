using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class SalesManReportController : Controller
    {
        //
        // GET: /SalesManReport/

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



            using (UserDBContext context = new UserDBContext())
            {
                ViewBag.SalesManList = context.Users.ToList();


                ViewBag.profit = "";

                int sellamount = 0;
                int buyamount = 0;
                int profit = 0;
                foreach (var money in context.SalesReports.ToList())
                {
                    sellamount += Convert.ToInt32(money.ProductPrice);
                    buyamount += Convert.ToInt32(money.BuyPrice);

                }
                ViewBag.totalsell = "Total Sold: " + sellamount + " BDT";
                ViewBag.profit = "Total Profit:   " + (sellamount - buyamount) + " BDT";

                return View(context.SalesReports.ToList());
            }
        }

        [HttpPost]
        public ActionResult Index(SalesReport sr)
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



           int id = Convert.ToInt32(Request["SalesmanID"]);
            ViewBag.salesmanid = id;
            List<SalesReport> salereport;
            using (UserDBContext context = new UserDBContext())
            {
                ViewBag.SalesManList = context.Users.ToList();
                if (id == 0)
                {
                    salereport = context.SalesReports.ToList();
                }
                else
                {
                    salereport = context.SalesReports.Where(x => x.SalesManId == id).ToList();
                }

                ViewBag.profit = "";

                int sellamount = 0;
                int buyamount = 0;
                int profit = 0;
                foreach (var money in salereport)
                {
                    sellamount += Convert.ToInt32(money.ProductPrice);
                    buyamount += Convert.ToInt32(money.BuyPrice);

                }
                ViewBag.totalsell = "Total Sold: " + sellamount + " BDT";
                ViewBag.profit = "Total Profit:   " + (sellamount - buyamount) + " BDT";

                return View(salereport.ToList());

            }
        }

    }
}
