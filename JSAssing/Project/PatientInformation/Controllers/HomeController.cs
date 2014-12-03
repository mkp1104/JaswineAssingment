using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientInformation.Models;
namespace PatientInformation.Controllers
{
    public class HomeController : Controller
    {
        PatientEntities dbContext = new PatientEntities();
        [HttpGet]
        public JsonResult GetPatientDetails()
        {

            var patientModel = dbContext.Patients.Select(p => new { p.patientName, p.patientId }).ToList();
                     return Json(patientModel, JsonRequestBehavior.AllowGet);
            }
        public JsonResult GetSubPatientDetails(int patientid)
        {

            var patientInfoModel = dbContext.Patients.Where(p => p.patientId == patientid).Select(x => new { x.patientName, x.patientAge, x.note }).ToList();
            return Json(patientInfoModel, JsonRequestBehavior.AllowGet);
           
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Patient Information System At Emids Technology For DotNet Devloper Training Engineer";

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
