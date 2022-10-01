using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult home()
        {
            return View();
        }
        public ActionResult education()
        {
            return View();
        }
        public ActionResult project()
        {
            return View();
        }
        public ActionResult reference()
        {
            return View();
        }
    }
}