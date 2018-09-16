using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlantDisease.Models;

namespace PlantDisease.Controllers
{
    public class AgricultureSpecialistsController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();

        // GET: AgricultureSpecialists
        public ActionResult Index()
        {
            var agricultureSpecialists = db.AgricultureSpecialists.Include(a => a.City);
            return View(agricultureSpecialists.ToList());
        }

        // GET: AgricultureSpecialists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgricultureSpecialist agricultureSpecialist = db.AgricultureSpecialists.Find(id);
            if (agricultureSpecialist == null)
            {
                return HttpNotFound();
            }
            return View(agricultureSpecialist);
        }

        // GET: AgricultureSpecialists/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: AgricultureSpecialists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Organization,Rates,Name,Email,MobileNumber,CityId,CreatedDate")] AgricultureSpecialist agricultureSpecialist)
        {
            if (ModelState.IsValid)
            {
                db.AgricultureSpecialists.Add(agricultureSpecialist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", agricultureSpecialist.CityId);
            return View(agricultureSpecialist);
        }

        // GET: AgricultureSpecialists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgricultureSpecialist agricultureSpecialist = db.AgricultureSpecialists.Find(id);
            if (agricultureSpecialist == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", agricultureSpecialist.CityId);
            return View(agricultureSpecialist);
        }

        // POST: AgricultureSpecialists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Organization,Rates,Name,Email,MobileNumber,CityId,CreatedDate")] AgricultureSpecialist agricultureSpecialist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agricultureSpecialist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", agricultureSpecialist.CityId);
            return View(agricultureSpecialist);
        }

        // GET: AgricultureSpecialists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgricultureSpecialist agricultureSpecialist = db.AgricultureSpecialists.Find(id);
            if (agricultureSpecialist == null)
            {
                return HttpNotFound();
            }
            return View(agricultureSpecialist);
        }

        // POST: AgricultureSpecialists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgricultureSpecialist agricultureSpecialist = db.AgricultureSpecialists.Find(id);
            db.AgricultureSpecialists.Remove(agricultureSpecialist);
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
