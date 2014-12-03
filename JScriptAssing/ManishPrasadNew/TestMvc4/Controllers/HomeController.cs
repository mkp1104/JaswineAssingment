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
    LibraryApplicationNewEntities1 dbContext = new LibraryApplicationNewEntities1();
    //
    // GET: /Home/
   
    [HttpGet]
    public JsonResult GetTopicDetails()
    {

      var topicModel = dbContext.Topics.Select(p => new { p.TopicName, p.TopicId }).ToList();
  //    var topicModel = dbContext.Topics.Select(p => p.topics).ToList();
      return Json(topicModel, JsonRequestBehavior.AllowGet);
      //return View("index",topicModel);
    }
    //[HttpPost]
    //public JsonResult CreateTopics()
    //{

    //  var topicModel = dbContext.Topics.Select(p => new { p.topics, p.topicId }).ToList();
    //  //    var topicModel = dbContext.Topics.Select(p => p.topics).ToList();
    //  return Json(topicModel, JsonRequestBehavior.);
    //  //return View("index",topicModel);
    //}
    public JsonResult GetSubTopicDetails(int topicid)
    {

      var subtopicModel = dbContext.Topics.Where(p => p.TopicId == topicid).Select(x=> new {x.TopicName, x.Duration,x.faculty}).ToList();
      return Json(subtopicModel, JsonRequestBehavior.AllowGet);
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
