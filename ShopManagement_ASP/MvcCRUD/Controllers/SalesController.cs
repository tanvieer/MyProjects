using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }


            int UserId = Convert.ToInt32(Session["UserId"].ToString());

            using (UserDBContext context = new UserDBContext())
            {
                var SalesReports = context.SalesReports.Where(x => x.SalesManId == UserId && x.SaleDate >= DateTime.UtcNow).ToList();
                return View(SalesReports);

            }

        }

        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }

            if (Session["SalesCart"] == null)
            {
                List<SalesReport> iList = new List<SalesReport>();
                Session["SalesCart"] = iList;
                Session["TotalPrice"] = "0.0";

            }


            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff");
            }

            // Session["UserId"] = "1454";


            SalesReport obj = new SalesReport();
            obj.SalesManId = Convert.ToInt32(Session["UserId"].ToString());
            string time = DateTime.UtcNow.ToString();
            obj.SaleTime = time.Substring(10, 10);
            obj.SaleDate = DateTime.Now;
            using (UserDBContext context = new UserDBContext())
            {
                var inventory = context.Inventories.Where(x => x.ProductQuantity > 0).ToList();
                ViewBag.Inventorynamelist = inventory;
                Session["inv"] = inventory;

                //ViewBag.Inventoryname = context.Inventories.Select(x => x.ProductName).ToList();

                //  var inventory = context.Inventories.Where(x => x.ProductQuantity == 2).ToList();

                //ViewBag.D = context.Inventories.Select(x => x.InventoryID).ToList();
            }

            return View(obj);




        }
        [HttpPost]
        public ActionResult Create(SalesReport model)
        {
            Session["error"] = "";
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff");
            }

            if (Session["SalesCart"] == null)
            {
                List<SalesReport> iList = new List<SalesReport>();
                Session["SalesCart"] = iList;
            }


            using (UserDBContext context = new UserDBContext())
            {
                ViewBag.Inventorynamelist = context.Inventories.ToList();
                Session["inv"] = context.Inventories.ToList();
            }


            int inID = Convert.ToInt32(Request["inID"].ToString());


            if (ModelState.IsValid)
            {
                if (model.Quantity >= 1)
                {
                    List<SalesReport> mList = new List<SalesReport>();
                    mList = (List<SalesReport>)Session["SalesCart"];
                    double price = 0.0;


                    List<Inventory> inv = (List<Inventory>)Session["inv"];

                    foreach (Inventory item in inv)
                    {
                        if (item.InventoryID == inID)
                        {
                            price = item.ProductSellPrice;
                            model.ProductName = item.ProductName.ToString();
                            model.BuyPrice = item.ProductBuyPrice;
                            break;
                        }
                    }
                    model.ProductPrice = price;
                    model.InventoryID = inID;
                    price = (price * Convert.ToDouble(model.Quantity));



                    Session["TotalPrice"] = (price + Convert.ToDouble(Session["TotalPrice"].ToString())).ToString();

                    mList.Add(model);
                    Session["SalesCart"] = mList;
                }

                // ModelState.Clear();
            }

            return View(model);
        }







        /* [HttpGet]
         public ActionResult Edit(int id)
         {
             List<SalesReport> mList = new List<SalesReport>();
             mList = (List<SalesReport>)Session["SalesCart"];

                 SalesReport sale = mList.SingleOrDefault(d => d.InventoryID == id);
                 return View(sale);

         }*/



        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff");
            }

            List<SalesReport> mList = new List<SalesReport>();
            mList = (List<SalesReport>)Session["SalesCart"];

            var inventory = mList.First(x => x.InventoryID == id);

            mList.Remove(inventory);

            Session["SalesCart"] = mList;

            List<SalesReport> invt = (List<SalesReport>)Session["SalesCart"];
            double taka = 0.0;
            foreach (SalesReport item in invt)
            {
                int q = Convert.ToInt32(item.Quantity);
                double p = Convert.ToDouble(Convert.ToDouble(item.ProductPrice) * q);
                taka += p;
            }
            Session["TotalPrice"] = taka.ToString();
            return RedirectToAction("Create");

        }


        public ActionResult SaveToDB()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LogOff");
            }

            List<SalesReport> mList = new List<SalesReport>();
            mList = (List<SalesReport>)Session["SalesCart"];


            using (UserDBContext context = new UserDBContext())
            {

                foreach (SalesReport s in mList)
                {
                    SalesReport sales = new SalesReport();
                    sales.InventoryID = s.InventoryID;
                    sales.ProductName = s.ProductName;
                    sales.ProductPrice = s.ProductPrice;
                    sales.Quantity = s.Quantity;

                    string time = DateTime.UtcNow.ToString();

                    sales.SaleDate = DateTime.Now;
                    sales.SaleTime = time.Substring(10, 10);
                    sales.SalesManId = Convert.ToInt32(Session["UserId"].ToString());
                    sales.SalesManName = Session["Name"].ToString();
                    sales.BuyPrice = s.BuyPrice;

                    Inventory obj = context.Inventories.Where(a => a.InventoryID.Equals(sales.InventoryID)).FirstOrDefault();

                    if (obj != null)
                    {
                        if (obj.ProductQuantity >= sales.Quantity) obj.ProductQuantity -= sales.Quantity;
                        else
                        {
                            Session["error"] = sales.ProductName.ToString() + " available only " + obj.ProductQuantity;


                            return RedirectToAction("Create");
                        }
                    }
                    else
                    {
                        Session["error"] = sales.ProductName + " not available in store.";

                        return RedirectToAction("Create");
                    }

                    context.SalesReports.Add(sales);
                }

                context.SaveChanges();


                List<SalesReport> iList = new List<SalesReport>();
                Session["SalesCart"] = iList;
                Session["TotalPrice"] = "0.0";
                Session["error"] = "";
                return RedirectToAction("Create");

            }

        }


    }
}
