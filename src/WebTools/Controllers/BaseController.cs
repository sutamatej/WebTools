using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebTools.Routing;

namespace WebTools.Controllers
{
    public abstract class BaseController : Controller
    {
        protected RedirectToRouteResult RedirectToAction<TController>(
            Expression<Action<TController>> action)
            where TController : Controller
        {
            var webRoute = new WebRoute<TController>(action);
            return RedirectToAction(webRoute.Action, webRoute.Controller, webRoute.Values);
        }
    }
}
