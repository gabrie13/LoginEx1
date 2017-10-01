using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogInEx1.Models;
using LogInEx1.Service;

namespace LogInEx1.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IStaffService _staffService = new StaffService();
        private readonly ILocationService _locationService = new LocationService();
        private readonly IPositionService _positionService = new PositionService();

        // GET: Staff
        public ActionResult Index()
        {
            //var employees = _staffService.Include(e => e.Location).Include(e => e.Position);

            var employees = _staffService.GetAll();
            var locations = _locationService.GetAll();
            var positions = _positionService.GetAll();
            return View(employees.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employee = _staffService.FindById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Location", "LocationName");
            ViewBag.Positionid = new SelectList(db.Positions, "Position", "PositionTitle");
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,Email,PhoneNumber,Address,City,State,ZipCode,HireDate,Wage,Positionid,LocationId")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                _staffService.Create(employee);
                return RedirectToAction("Index");
            }

            //ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", employee.LocationId);
            //ViewBag.Positionid = new SelectList(db.Positions, "PositionId", "PositionTitle", employee.Positionid);
            _locationService.GetAll().ToList();
            _positionService.GetAll().ToList();

            return View(employee);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", employee.LocationId);
            ViewBag.Positionid = new SelectList(db.Positions, "PositionId", "PositionTitle", employee.Positionid);
            return View(employee);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,Email,PhoneNumber,Address,City,State,ZipCode,HireDate,Wage,Positionid,LocationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", employee.LocationId);
            ViewBag.Positionid = new SelectList(db.Positions, "PositionId", "PositionTitle", employee.Positionid);
            return View(employee);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
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
