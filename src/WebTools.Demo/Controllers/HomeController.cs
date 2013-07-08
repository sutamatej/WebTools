using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTools.Controllers;
using WebTools.Demo.Models;

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

        public ActionResult Save(HomeModel model)
        {
            return this.RedirectToAction(c => c.Land());
        }
    }
}
