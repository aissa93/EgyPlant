﻿using System;
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
    public class PlantDiseaseFactorsController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();

        // GET: PlantDiseaseFactors
        public ActionResult Index()
        {
            var plantDiseaseFactors = db.PlantDiseaseFactors.Include(p => p.Factor).Include(p => p.PlantDiseaseJunc);
            return View(plantDiseaseFactors.ToList());
        }

        // GET: PlantDiseaseFactors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFactor plantDiseaseFactor = db.PlantDiseaseFactors.Find(id);
            if (plantDiseaseFactor == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseFactor);
        }

        // GET: PlantDiseaseFactors/Create
        public ActionResult Create()
        {
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name");
            ViewBag.PlantDiseaseId = new SelectList(db.PlantDiseaseJuncs, "Id", "Id");
            return View();
        }

        // POST: PlantDiseaseFactors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantDiseaseId,FactorId,From,To,CreationDate,CreatedBy")] PlantDiseaseFactor plantDiseaseFactor)
        {
            if (ModelState.IsValid)
            {
                db.PlantDiseaseFactors.Add(plantDiseaseFactor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", plantDiseaseFactor.FactorId);
            ViewBag.PlantDiseaseId = new SelectList(db.PlantDiseaseJuncs, "Id", "Id", plantDiseaseFactor.PlantDiseaseId);
            return View(plantDiseaseFactor);
        }

        // GET: PlantDiseaseFactors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFactor plantDiseaseFactor = db.PlantDiseaseFactors.Find(id);
            if (plantDiseaseFactor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", plantDiseaseFactor.FactorId);
            ViewBag.PlantDiseaseId = new SelectList(db.PlantDiseaseJuncs, "Id", "Id", plantDiseaseFactor.PlantDiseaseId);
            return View(plantDiseaseFactor);
        }

        // POST: PlantDiseaseFactors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantDiseaseId,FactorId,From,To,CreationDate,CreatedBy")] PlantDiseaseFactor plantDiseaseFactor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantDiseaseFactor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Name", plantDiseaseFactor.FactorId);
            ViewBag.PlantDiseaseId = new SelectList(db.PlantDiseaseJuncs, "Id", "Id", plantDiseaseFactor.PlantDiseaseId);
            return View(plantDiseaseFactor);
        }

        // GET: PlantDiseaseFactors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseFactor plantDiseaseFactor = db.PlantDiseaseFactors.Find(id);
            if (plantDiseaseFactor == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseFactor);
        }

        // POST: PlantDiseaseFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantDiseaseFactor plantDiseaseFactor = db.PlantDiseaseFactors.Find(id);
            db.PlantDiseaseFactors.Remove(plantDiseaseFactor);
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
