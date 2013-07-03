using Moq;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTools.Tests.Helpers
{
    public static class HtmlHelperBuilder
    {
        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel model)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new Mock<IViewEngine>().Object);

            var controller = new Mock<Controller>().Object;
            var httpContext = new Mock<HttpContextBase>().Object;

            var viewDataContainer = new Mock<IViewDataContainer>();
            viewDataContainer.Setup(vdc => vdc.ViewData).Returns(new ViewDataDictionary(model));
            var viewData = viewDataContainer.Object;

            var routeData = new RouteData();
            routeData.Values["controller"] = "home";
            routeData.Values["action"] = "index";

            var requestContext = new Mock<RequestContext>(httpContext, routeData).Object;

            ControllerContext controllerContext = new Mock<ControllerContext>(requestContext, controller).Object;

            var viewContext = new Mock<ViewContext>();
            viewContext.Setup(vc => vc.Controller).Returns(controllerContext.Controller);
            viewContext.Setup(vc => vc.View).Returns(new RazorView(controllerContext, "TestView", "Layout", false, new string[] { }));
            viewContext.Setup(vc => vc.ViewData).Returns(new ViewDataDictionary());
            viewContext.Setup(vc => vc.TempData).Returns(new TempDataDictionary());
            viewContext.Setup(vc => vc.Writer).Returns(new StringWriter(new StringBuilder()));
            viewContext.Setup(vc => vc.RouteData).Returns(routeData);
            viewContext.Setup(vc => vc.HttpContext).Returns(httpContext);
            viewContext.Setup(vc => vc.ClientValidationEnabled).Returns(false);
            viewContext.Setup(vc => vc.UnobtrusiveJavaScriptEnabled).Returns(false);
            viewContext.Setup(vc => vc.FormContext).Returns(new Mock<FormContext>().Object);

            HtmlHelper<TModel> htmlHelper = new HtmlHelper<TModel>(viewContext.Object, viewData);
            return htmlHelper;
        }
    }
}
