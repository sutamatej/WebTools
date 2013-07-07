using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTools.Controllers;

namespace WebTools.Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Go()
        {
            return this.RedirectToAction<HomeController>(c => c.Land());
        }

        public ActionResult Land()
        {
            return View();
        }
    }
}
