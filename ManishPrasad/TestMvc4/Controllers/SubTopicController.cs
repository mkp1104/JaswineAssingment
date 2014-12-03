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
    public class SubTopicController : Controller
    {
        private LibraryApplicationEntities db = new LibraryApplicationEntities();

        //
        // GET: /SubTopic/

        public ActionResult Index()
        {
            var subtopics = db.SubTopics.Include("Topic");
            return View(subtopics.ToList());
        }

        //
        // GET: /SubTopic/Details/5

        public ActionResult Details(int id = 0)
        {
            SubTopic subtopic = db.SubTopics.Single(s => s.subtopicId == id);
            if (subtopic == null)
            {
                return HttpNotFound();
            }
            return View(subtopic);
        }

        //
        // GET: /SubTopic/Create

        public ActionResult Create()
        {
            ViewBag.indexId = new SelectList(db.Topics, "topicId", "topics");
            return View();
        }

        //
        // POST: /SubTopic/Create

        [HttpPost]
        public ActionResult Create(SubTopic subtopic)
        {
            if (ModelState.IsValid)
            {
                db.SubTopics.AddObject(subtopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.indexId = new SelectList(db.Topics, "topicId", "topics", subtopic.indexId);
            return View(subtopic);
        }

        //
        // GET: /SubTopic/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubTopic subtopic = db.SubTopics.Single(s => s.subtopicId == id);
            if (subtopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.indexId = new SelectList(db.Topics, "topicId", "topics", subtopic.indexId);
            return View(subtopic);
        }

        //
        // POST: /SubTopic/Edit/5

        [HttpPost]
        public ActionResult Edit(SubTopic subtopic)
        {
            if (ModelState.IsValid)
            {
                db.SubTopics.Attach(subtopic);
                db.ObjectStateManager.ChangeObjectState(subtopic, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.indexId = new SelectList(db.Topics, "topicId", "topics", subtopic.indexId);
            return View(subtopic);
        }

        //
        // GET: /SubTopic/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubTopic subtopic = db.SubTopics.Single(s => s.subtopicId == id);
            if (subtopic == null)
            {
                return HttpNotFound();
            }
            return View(subtopic);
        }

        //
        // POST: /SubTopic/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTopic subtopic = db.SubTopics.Single(s => s.subtopicId == id);
            db.SubTopics.DeleteObject(subtopic);
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