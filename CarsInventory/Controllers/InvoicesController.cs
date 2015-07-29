using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsInventory.DataContext;
using CarsInventory.Entities;

namespace CarsInventory.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly InventoryDb _content;

        public InvoicesController(InventoryDb content)
        {
            _content = content;
            
        }
        

        // GET: Invoices
        public ActionResult Index()
        {
            return View(_content .Invoice.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoice = _content.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_content.Vehicles.OrderBy(v => v.Description),"Id","Description");
            
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,VehicleId,Hirer,EMailAddress,Telephone,Destination,StartDate,EndDate,Comment,Price,NumberOFDays")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _content.Invoice.Add(invoice);
                _content.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {

            var xx = _content.Invoice.SingleOrDefault(v => v.Vehicle.Id.Equals(3));


            ViewBag.Vehicles = new SelectList(_content.Vehicles.OrderBy(v => v.Description), "Id", "Description");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoice = _content.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,VehicleId,Hirer,EMailAddress,Telephone,Destination,StartDate,EndDate,Comment,Price,NumberOFDays")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _content.Entry(invoice).State = EntityState.Modified;
                _content.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = _content.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = _content.Invoice.Find(id);
            _content.Invoice.Remove(invoice);
            _content.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _content.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
