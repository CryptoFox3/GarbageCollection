using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbageCollection.Models;
using Microsoft.AspNet.Identity;

namespace GarbageCollection.Controllers
{
    [Authorize(Roles = "Customer,Employee,Admin")]
    public class CustomerModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerModels
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        //public ActionResult IndexOne()
        //{
        // //   var customer = db.Users.
        //  //  return View(customer);
        //}

        // GET: CustomerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.Customers.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // GET: CustomerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomersId,UserId,Username,FirstName,LastName,Email,Address,ZipCode,AmountDue,PickupDate")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                customerModels.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerModels);
        }

        // GET: CustomerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.Customers.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        public ActionResult Billing(int? id)
        {
            var customer = db.Customers.Find(id);
            return View(customer.AmountDue);
        }

        // POST: CustomerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomersId,UserId,Username,FirstName,LastName,Email,Address,ZipCode,AmountDue,PickupDate")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerModels);
        }

        // GET: CustomerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.Customers.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // POST: CustomerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModels customerModels = db.Customers.Find(id);
            db.Customers.Remove(customerModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Billing")]
        public ActionResult DisplayAmountDue(int id)
        {
            var customer = db.Customers.Where(c => c.CustomersId.Equals(id)).First();
            return View(customer);
        }

        [HttpPost, ActionName("MyPickups")]
        public ActionResult DisplayMyPickups(int id)
        {
            var customer = db.Customers.Where(c => c.CustomersId.Equals(id)).First();
            return View(customer);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
