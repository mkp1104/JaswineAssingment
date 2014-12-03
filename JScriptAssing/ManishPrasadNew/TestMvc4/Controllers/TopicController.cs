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
    public class TopicController : Controller
    {
      private LibraryApplicationNewEntities1 db = new LibraryApplicationNewEntities1();

        //
        // GET: /Topic/

        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id = 0)
        {
            Topic topic = db.Topics.Single(t => t.TopicId == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        //
        // GET: /Topic/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Topic/Create

        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.AddObject(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        //
        // GET: /Topic/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Topic topic = db.Topics.Single(t => t.TopicId == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        //
        // POST: /Topic/Edit/5

        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Attach(topic);
                db.ObjectStateManager.ChangeObjectState(topic, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        //
        // GET: /Topic/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Topic topic = db.Topics.Single(t => t.TopicId == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        //
        // POST: /Topic/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Single(t => t.TopicId == id);
            db.Topics.DeleteObject(topic);
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