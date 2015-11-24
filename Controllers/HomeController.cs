using System;
using System.Web.Mvc;
using SupplementsPlannerWeb.Controllers.Services;
using System.Web.Script.Serialization;

namespace SupplementsPlannerWeb.Controllers
{
    public class SupplementsPlannerController : Controller
    {
        //
        // GET: /SupplementsPlanner/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetSupplements(string type)
        {
            var service = new SupplementService();
            return Content(new JavaScriptSerializer().Serialize(service.GetSupplementsByType(type)));
        }

        [HttpPost]
        public ActionResult GetSupplementRelations(int id, string type)
        {
            var service = new RelationInformationService();
            return Content(new JavaScriptSerializer().Serialize(service.GetSupplementRelations(id, type)));
        }
	}
}