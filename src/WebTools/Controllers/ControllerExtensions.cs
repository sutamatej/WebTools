using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebTools.Routing;

namespace WebTools.Controllers
{
    public static class ControllerExtensions
    {
        public static RedirectToRouteResult RedirectToAction<TController>(
            this TController controller,
            Expression<Action<TController>> action)
            where TController : Controller
        {
            var route = new WebRoute<TController>(action);
            return new RedirectToRouteResult(route.Route);
        }
    }
}
