using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvc4.Models;

namespace TestMvc4.Controllers
{
    public class SubTopicDetailController : Controller
    {
        private LibraryApplicationEntities db = new LibraryApplicationEntities();

        //
        // GET: /SubTopicDetail/

        public ActionResult Index()
        {
            var subtopicdetails = db.SubTopicDetails.Include("SubTopic");
            return View(subtopicdetails.ToList());
        }

        //
        // GET: /SubTopicDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            SubTopicDetail subtopicdetail = db.SubTopicDetails.Single(s => s.stdID == id);
            if (subtopicdetail == null)
            {
                return HttpNotFound();
            }
            return View(subtopicdetail);
        }

        //
        // GET: /SubTopicDetail/Create

        public ActionResult Create()
        {
            ViewBag.subtopicId = new SelectList(db.SubTopics, "subtopicId", "subtopics");
            return View();
        }

        //
        // POST: /SubTopicDetail/Create

        [HttpPost]
        public ActionResult Create(SubTopicDetail subtopicdetail)
        {
            if (ModelState.IsValid)
            {
                db.SubTopicDetails.AddObject(subtopicdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subtopicId = new SelectList(db.SubTopics, "subtopicId", "subtopics", subtopicdetail.subtopicId);
            return View(subtopicdetail);
        }

        //
        // GET: /SubTopicDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubTopicDetail subtopicdetail = db.SubTopicDetails.Single(s => s.stdID == id);
            if (subtopicdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.subtopicId = new SelectList(db.SubTopics, "subtopicId", "subtopics", subtopicdetail.subtopicId);
            return View(subtopicdetail);
        }

        //
        // POST: /SubTopicDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(SubTopicDetail subtopicdetail)
        {
            if (ModelState.IsValid)
            {
                db.SubTopicDetails.Attach(subtopicdetail);
                db.ObjectStateManager.ChangeObjectState(subtopicdetail, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subtopicId = new SelectList(db.SubTopics, "subtopicId", "subtopics", subtopicdetail.subtopicId);
            return View(subtopicdetail);
        }

        //
        // GET: /SubTopicDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubTopicDetail subtopicdetail = db.SubTopicDetails.Single(s => s.stdID == id);
            if (subtopicdetail == null)
            {
                return HttpNotFound();
            }
            return View(subtopicdetail);
        }

        //
        // POST: /SubTopicDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTopicDetail subtopicdetail = db.SubTopicDetails.Single(s => s.stdID == id);
            db.SubTopicDetails.DeleteObject(subtopicdetail);
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