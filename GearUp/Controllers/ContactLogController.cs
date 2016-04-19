using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearUp.Controllers
{
    [Authorize]
    public class ContactLogController : Controller
    {
        // GET: ContactLog
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //// POST: ContactLog
        //public ActionResult Index(Model model)
        //{
        //    return View();
        //}
    }
}