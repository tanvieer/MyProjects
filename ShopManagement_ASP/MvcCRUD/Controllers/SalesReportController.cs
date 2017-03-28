using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class SalesReportController : Controller
    {

        [HttpGet]
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








            ViewBag.amount = "Month";
           
            using (UserDBContext context = new UserDBContext())
            {
                ViewBag.profit = "";

                int sellamount = 0;
                int buyamount = 0;
                int profit = 0;
                foreach (var money in context.SalesReports.ToList())
                {
                    sellamount += Convert.ToInt32(money.ProductPrice);
                    buyamount += Convert.ToInt32(money.BuyPrice);

                }
                ViewBag.totalsell = "Total Sold: " +sellamount+ " BDT";
                ViewBag.profit = "Total Profit:   " + (sellamount - buyamount)+" BDT";

                return View(context.SalesReports.ToList());
            }

        }
        [HttpPost]
        public ActionResult Index(SalesReport Sr)
        {
            DateTime startdate;
            DateTime enddate;
            if ((Request["StartDate"]) != null && (Request["EndDate"]) != null && Request["StartDate"] !="" && (Request["EndDate"]) != "")
            {
                 startdate = Convert.ToDateTime((Request["StartDate"]));
                 enddate = Convert.ToDateTime((Request["EndDate"]));
            }
            else
            {
                startdate = DateTime.UtcNow;
                enddate = DateTime.Now;
                enddate.AddDays(1);

            }

                
        


          //  DateTime today = DateTime.UtcNow; // As DateTime
           // string s_today = today.ToString("MM/dd/yyyy");
            //today = Convert.ToDateTime(s_today);
            //today = today.AddDays(Convert.ToDouble(amount));

            using (UserDBContext context = new UserDBContext())
            {
                List<SalesReport> salesreport = context.SalesReports.Where(d => d.SaleDate >= startdate && d.SaleDate <= enddate).ToList();

                int sellamount = 0;
                int buyamount = 0;
                int profit = 0;
                foreach (var money in salesreport)
                {
                    sellamount += Convert.ToInt32(money.ProductPrice);
                    buyamount += Convert.ToInt32(money.BuyPrice);

                }
                ViewBag.totalsell = "Total Sold: " + sellamount + " BDT";
                ViewBag.profit = "Total Profit:   " + (sellamount-buyamount)+" BDT";


                return View(salesreport);
            }

        }


    }
}
