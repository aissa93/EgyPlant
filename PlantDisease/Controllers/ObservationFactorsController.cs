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
    public class ObservationFactorsController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();

        // GET: ObservationFactors
        public ActionResult Index()
        {
            var observationFactors = db.ObservationFactors.Include(o => o.Factor).Include(o => o.Observation);
            return View(observationFactors.ToList());
        }

        // GET: ObservationFactors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationFactor observationFactor = db.ObservationFactors.Find(id);
            if (observationFactor == null)
            {
                return HttpNotFound();
            }
            return View(observationFactor);
        }

        // GET: ObservationFactors/Create
        public ActionResult Create()
        {
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name");
            ViewBag.ObservationId = new SelectList(db.Observations, "Id", "Id");
            return View();
        }

        // POST: ObservationFactors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FactorId,FactorValue,ObservationId")] ObservationFactor observationFactor)
        {
            if (ModelState.IsValid)
            {
                db.ObservationFactors.Add(observationFactor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", observationFactor.FactorId);
            ViewBag.ObservationId = new SelectList(db.Observations, "Id", "Id", observationFactor.ObservationId);
            return View(observationFactor);
        }

        // GET: ObservationFactors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationFactor observationFactor = db.ObservationFactors.Find(id);
            if (observationFactor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", observationFactor.FactorId);
            ViewBag.ObservationId = new SelectList(db.Observations, "Id", "Id", observationFactor.ObservationId);
            return View(observationFactor);
        }

        // POST: ObservationFactors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FactorId,FactorValue,ObservationId")] ObservationFactor observationFactor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observationFactor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", observationFactor.FactorId);
            ViewBag.ObservationId = new SelectList(db.Observations, "Id", "Id", observationFactor.ObservationId);
            return View(observationFactor);
        }

        // GET: ObservationFactors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationFactor observationFactor = db.ObservationFactors.Find(id);
            if (observationFactor == null)
            {
                return HttpNotFound();
            }
            return View(observationFactor);
        }

        // POST: ObservationFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObservationFactor observationFactor = db.ObservationFactors.Find(id);
            db.ObservationFactors.Remove(observationFactor);
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
