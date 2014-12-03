using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientInformation.Models;

namespace PatientInformation.Controllers
{
    public class PatientInformationController : Controller
    {
        private PatientEntities db = new PatientEntities();

        //
        // GET: /PatientInformation/

        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        //
        // GET: /PatientInformation/Details/5

        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // GET: /PatientInformation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PatientInformation/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.AddObject(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        //
        // GET: /PatientInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /PatientInformation/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Attach(patient);
                db.ObjectStateManager.ChangeObjectState(patient, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        //
        // GET: /PatientInformation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /PatientInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            db.Patients.DeleteObject(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}