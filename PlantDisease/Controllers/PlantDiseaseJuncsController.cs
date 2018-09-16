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
    public class PlantDiseaseJuncsController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();

        // GET: PlantDiseaseJuncs
        public ActionResult Index()
        {
            var plantDiseaseJuncs = db.PlantDiseaseJuncs.Include(p => p.Disease).Include(p => p.Plant);
            return View(plantDiseaseJuncs.ToList());
        }

        // GET: PlantDiseaseJuncs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseJunc plantDiseaseJunc = db.PlantDiseaseJuncs.Find(id);
            if (plantDiseaseJunc == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseJunc);
        }

        // GET: PlantDiseaseJuncs/Create
        public ActionResult Create()
        {
            ViewBag.DiseaseId = new SelectList(db.Diseases, "Id", "Name");
            ViewBag.PlantId = new SelectList(db.Plants, "Id", "Name");
            return View();
        }

        // POST: PlantDiseaseJuncs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantId,DiseaseId,CreationDate,CreatedBy")] PlantDiseaseJunc plantDiseaseJunc)
        {
            if (ModelState.IsValid)
            {
                db.PlantDiseaseJuncs.Add(plantDiseaseJunc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiseaseId = new SelectList(db.Diseases, "Id", "Name", plantDiseaseJunc.DiseaseId);
            ViewBag.PlantId = new SelectList(db.Plants, "Id", "Name", plantDiseaseJunc.PlantId);
            return View(plantDiseaseJunc);
        }

        // GET: PlantDiseaseJuncs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseJunc plantDiseaseJunc = db.PlantDiseaseJuncs.Find(id);
            if (plantDiseaseJunc == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "Id", "Name", plantDiseaseJunc.DiseaseId);
            ViewBag.PlantId = new SelectList(db.Plants, "Id", "Name", plantDiseaseJunc.PlantId);
            return View(plantDiseaseJunc);
        }

        // POST: PlantDiseaseJuncs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantId,DiseaseId,CreationDate,CreatedBy")] PlantDiseaseJunc plantDiseaseJunc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantDiseaseJunc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "Id", "Name", plantDiseaseJunc.DiseaseId);
            ViewBag.PlantId = new SelectList(db.Plants, "Id", "Name", plantDiseaseJunc.PlantId);
            return View(plantDiseaseJunc);
        }

        // GET: PlantDiseaseJuncs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantDiseaseJunc plantDiseaseJunc = db.PlantDiseaseJuncs.Find(id);
            if (plantDiseaseJunc == null)
            {
                return HttpNotFound();
            }
            return View(plantDiseaseJunc);
        }

        // POST: PlantDiseaseJuncs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantDiseaseJunc plantDiseaseJunc = db.PlantDiseaseJuncs.Find(id);
            db.PlantDiseaseJuncs.Remove(plantDiseaseJunc);
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
