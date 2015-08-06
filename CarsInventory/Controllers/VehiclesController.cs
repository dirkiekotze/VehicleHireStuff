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
using CarsInventory.Infastructure;
using CarsInventory.Infastructure.Alerts;
using Microsoft.AspNet.Identity;
using Microsoft.Web.Mvc;

namespace CarsInventory.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly InventoryDb db = new InventoryDb();
        private InventoryDb _db;
        private readonly ICurrentUser _user;


        public VehiclesController(InventoryDb db, ICurrentUser user)
        {
            _db = db;
            _user = user;
        }



        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,NumberOfSeats,RegistrationNo,Kms")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                db.Vehicles.Add(vehicle);
                db.LogAction.Add(new LogAction(_user.User.UserName, "Create", "Vhicle", "Created Vehicle"));
                db.SaveChanges();
                return this.RedirectToAction<VehiclesController>(c => c.Index()).WithSuccess("Vehicle Created");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,NumberOfSeats,RegistrationNo,Kms,FuelType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return this.RedirectToAction<VehiclesController>(c => c.Index()).WithSuccess("Edit Vehicle");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                this.RedirectToAction<VehiclesController>(c => c.Index()).WithError("Vehicle was not Found");
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vehicle = db.Vehicles.Find(id);

            if (vehicle == null)
            {
                return this.RedirectToAction<VehiclesController>(c => c.Index()).WithError("Vehicle was not Found");
            }

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return this.RedirectToAction<VehiclesController>(c => c.Index()).WithSuccess("Deleted Vehicle."); 
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
