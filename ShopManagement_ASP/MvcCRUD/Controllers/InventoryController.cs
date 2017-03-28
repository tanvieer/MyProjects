using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class InventoryController : Controller
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



            ViewBag.amount = 1000;
            using (UserDBContext context = new UserDBContext())
            {
                return View(context.Inventories.ToList());
            }

        }

        [HttpPost]
        public ActionResult Index(Inventory inv)
        {
            int amount = 1000;
            if (Request["Productlessthan"] != null)
                amount = Convert.ToInt32(Request["Productlessthan"]);
            if (amount < 0)
                amount = 1000;

            ViewBag.amount = amount;

            using (UserDBContext context = new UserDBContext())
            {
                List<Inventory> inventory = context.Inventories.Where(x => x.ProductQuantity <= amount).ToList();



                return View(inventory);
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
                if (type.Equals("Salesman")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Inventory inventory)
        {
            using (UserDBContext context = new UserDBContext())
            {
                if (ModelState.IsValid)
                {
                    context.Inventories.Add(inventory);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(inventory);
                }
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
                if (type.Equals("Salesman")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }


            using (UserDBContext context = new UserDBContext())
            {
                Inventory inventory = context.Inventories.SingleOrDefault(d => d.InventoryID == id);
                return View(inventory);
            }
        }

        [HttpPost]
        public ActionResult Edit(Inventory inventory)
        {
            using (UserDBContext context = new UserDBContext())
            {
                Inventory invenoUpdate = context.Inventories.SingleOrDefault(d => d.InventoryID == inventory.InventoryID);
                invenoUpdate.ProductName = inventory.ProductName;
                invenoUpdate.ProductBuyPrice = inventory.ProductBuyPrice;
                invenoUpdate.ProductSellPrice = inventory.ProductSellPrice;
                invenoUpdate.ProductQuantity = inventory.ProductQuantity;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
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
                if (type.Equals("Salesman")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }



            using (UserDBContext context = new UserDBContext())
            {
                Inventory inventory = context.Inventories.SingleOrDefault(d => d.InventoryID == id);
                return View(inventory);
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
                if (type.Equals("Salesman")) return RedirectToAction("LogOff", "User");
            }
            catch
            {
                return RedirectToAction("LogOff", "User");
            }



            using (UserDBContext context = new UserDBContext())
            {
                Inventory inventory = context.Inventories.SingleOrDefault(d => d.InventoryID == id);
                return View(inventory);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
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
                Inventory inventory = context.Inventories.SingleOrDefault(d => d.InventoryID == id);
                context.Inventories.Remove(inventory);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
