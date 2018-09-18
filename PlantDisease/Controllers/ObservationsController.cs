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
    public class ObservationsController : Controller
    {
        private PlantDiseaseContext db = new PlantDiseaseContext();
        
        // GET: Observations
        public ActionResult Index()
        {
            var observations = db.Observations.Include(o => o.PlantDiseaseJunc).Include(o => o.Plant);
            return View(observations.ToList());
        }
        public ObservationsController() {
            

        }
        // GET: Observations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        // GET: Observations/Create
        public ActionResult Create()
        {
            ViewBag.PlantId = new SelectList(db.Plants, "Id", "Name");
            ViewBag.DiseaseId = new SelectList(db.Diseases, "Id", "Name");
            ViewBag.Factors = new SelectList(db.Factors, "Id", "Name");


            return View();
        }

       
        // POST: Observations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObservationConfigViewModel config,string Facts)
        {
            if (ModelState.IsValid)
            {
                config.Factors = Facts.Split(',');
                int PlantDiseaseId;
                int ObservationId;

                if (db.PlantDiseaseJuncs.FirstOrDefault(p => p.DiseaseId == config.DiseaseId && p.PlantId == config.PlantId) == null)
                {
                    db.PlantDiseaseJuncs.Add(new PlantDiseaseJunc() { PlantId = config.PlantId, DiseaseId = config.DiseaseId});
                    db.SaveChanges();
                   PlantDiseaseId= db.PlantDiseaseJuncs.FirstOrDefault(p => p.DiseaseId == config.DiseaseId && p.PlantId == config.PlantId).Id;
                }
                else {
                    PlantDiseaseId = db.PlantDiseaseJuncs.FirstOrDefault(p => p.DiseaseId == config.DiseaseId && p.PlantId == config.PlantId).Id;

                }

                db.Observations.Add(new Observation() {PlantDiseaseId=PlantDiseaseId,CreatedBy=1,CreatedDate=DateTime.Now,ObservationDate=DateTime.Now ,Name=config.Name});
                db.SaveChanges();

                ObservationId= db.Observations.FirstOrDefault(o => o.PlantDiseaseId == PlantDiseaseId).Id;

                foreach (string factor in config.Factors)
                {
                    if (!string.IsNullOrEmpty(factor)) {
                        db.ObservationFactors.Add(new ObservationFactor() { ObservationId = ObservationId, FactorId = Convert.ToInt32(factor) });

                    }

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantDiseaseId = new SelectList(db.Plants, "Id", "Name", config.PlantId);
            ViewBag.PlantDiseaseId = new SelectList(db.Diseases, "Id", "Name", config.DiseaseId);
            ViewBag.Factors = new SelectList(db.Factors, "Id", "Name");

            return View();
        }

        // GET: Observations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observation observation = db.Observations.Find(id);


            ObservationSheet sheet = new ObservationSheet();
            sheet.ObservationName = observation.Name;
            sheet.ObservationId = observation.Id;
            sheet.Infected = observation.InfectionClassification;
            sheet.InfectedValue = observation.InfectionValue;


            var facs = (from ob in db.ObservationFactors
                              join f in db.Factors
                               on ob.FactorId equals f.Id
                              where ob.ObservationId == observation.Id
                              select new SheetFactor
                              {
                                  FactorId = ob.FactorId,
                                  FactorValue = ob.FactorValue,
                                  FactorName=f.Name
                              }).Take(10);
            //var facs= db.ObservationFactors.Where(of => of.ObservationId == observation.Id).Select(P=>new { P.FactorId, P.FactorValue}) ;
            ViewBag.SheetFactors = facs;

            if (observation == null)
            {
                return HttpNotFound();
            }
           
            return View(sheet);
        }

        // POST: Observations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ObservationDate,PlantDiseaseId,InfectionClassification,InfectionValue,CreatedBy,CreatedDate")] Observation observation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantDiseaseId = new SelectList(db.PlantDiseaseJuncs, "Id", "Id", observation.PlantDiseaseId);
            ViewBag.PlantDiseaseId = new SelectList(db.Plants, "Id", "Name", observation.PlantDiseaseId);
            return View(observation);
        }

        // GET: Observations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        // POST: Observations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Observation observation = db.Observations.Find(id);
            db.Observations.Remove(observation);
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
