using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvc4.Models;

namespace TestMvc4.Controllers
{
  public class HomeController : Controller
  {
   LibraryApplicationEntities  dbContext = new LibraryApplicationEntities();
    //
    // GET: /Home/
   
    [HttpGet]
    public JsonResult GetTopicDetails()
    {

      var topicModel = dbContext.Topics.Select(p => new { p.topics, p.topicId }).ToList();
  //    var topicModel = dbContext.Topics.Select(p => p.topics).ToList();
      return Json(topicModel, JsonRequestBehavior.AllowGet);
      //return View("index",topicModel);
    }
    public JsonResult GetSubTopicDetails(int topicid)
    {

      var subtopicModel = dbContext.SubTopics.Where(p => p.indexId == topicid).Select(x=> new {x.subtopicId, x.subtopics}).ToList();
      return Json(subtopicModel, JsonRequestBehavior.AllowGet);
      //return View("index",topicModel);
    }
    public JsonResult GetSubTopicContent(int subtopicid)
    {

      var subtopicContentModel = dbContext.SubTopicDetails.Where(p => p.subtopicId == subtopicid).Select(x => new { x.stdID,x.Description,x.DURATION,x.FACULTY}).ToList();
      return Json(subtopicContentModel, JsonRequestBehavior.AllowGet);
      //return View("index",topicModel);
    }
    public ActionResult Index()
    {
      ViewBag.Message = "Training Modules At Emids Technology For DotNet Devloper Training Engineer";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
