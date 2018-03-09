using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerOrderProject.Models;
using CustomerOrderProject.Utility;

namespace CustomerOrderProject.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult List()
        {
            return Json(db.Customers.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        // /Customer/Create [POST]
        public ActionResult Create([System.Web.Http.FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "Model State is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Customers.Add(customer);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Customer was created."));
        }

        // Customer/Change [POST]
        public ActionResult Change([System.Web.Http.FromBody] Customer customer)
        {
            Customer customer2 = db.Customers.Find(customer.Id);
            customer2.Name = customer.Name;
            customer2.CreditLimit = customer.CreditLimit;
            customer2.Active = customer.Active;
                try
                {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Customer was changed."));
        }

        // Customer/Remove [POST]
        public ActionResult Remove([System.Web.Http.FromBody] Customer customer)
        {
            Customer customer2 = db.Customers.Find(customer.Id);
            db.Customers.Remove(customer2);
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Customer was deleted."));
        }
    }

}
