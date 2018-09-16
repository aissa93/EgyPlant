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
    public class PlantDiseaseFeedbacksController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();

        // GET: PlantDiseaseFeedbacks
        public ActionResult Index()
        {
            var plantDiseaseFeedbacks = db.PlantDiseaseFeedbacks.Include(p => p.PlantDiseaseFactor);
            return View(plantDiseaseFeedbacks.ToList());
        }

        // GET: PlantDiseaseFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFeedback plantDiseaseFeedback = db.PlantDiseaseFeedbacks.Find(id);
            if (plantDiseaseFeedback == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseFeedback);
        }

        // GET: PlantDiseaseFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.PlantDiseaseFactorId = new SelectList(db.PlantDiseaseFactors, "Id", "Id");
            return View();
        }

        // POST: PlantDiseaseFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgricultureSpecialistId,PlantDiseaseFactorId")] PlantDiseaseFeedback plantDiseaseFeedback)
        {
            if (ModelState.IsValid)
            {
                db.PlantDiseaseFeedbacks.Add(plantDiseaseFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantDiseaseFactorId = new SelectList(db.PlantDiseaseFactors, "Id", "Id", plantDiseaseFeedback.PlantDiseaseFactorId);
            return View(plantDiseaseFeedback);
        }

        // GET: PlantDiseaseFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFeedback plantDiseaseFeedback = db.PlantDiseaseFeedbacks.Find(id);
            if (plantDiseaseFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantDiseaseFactorId = new SelectList(db.PlantDiseaseFactors, "Id", "Id", plantDiseaseFeedback.PlantDiseaseFactorId);
            return View(plantDiseaseFeedback);
        }

        // POST: PlantDiseaseFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgricultureSpecialistId,PlantDiseaseFactorId")] PlantDiseaseFeedback plantDiseaseFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantDiseaseFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantDiseaseFactorId = new SelectList(db.PlantDiseaseFactors, "Id", "Id", plantDiseaseFeedback.PlantDiseaseFactorId);
            return View(plantDiseaseFeedback);
        }

        // GET: PlantDiseaseFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFeedback plantDiseaseFeedback = db.PlantDiseaseFeedbacks.Find(id);
            if (plantDiseaseFeedback == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseFeedback);
        }

        // POST: PlantDiseaseFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantDiseaseFeedback plantDiseaseFeedback = db.PlantDiseaseFeedbacks.Find(id);
            db.PlantDiseaseFeedbacks.Remove(plantDiseaseFeedback);
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
