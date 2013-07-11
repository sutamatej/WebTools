using Moq;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTools.Tests.Helpers
{
    public static class HtmlHelperBuilder
    {
        public static HtmlHelper<TModel> GetTypedHtmlHelper<TModel>(TModel model)
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

        public static HtmlHelper GetHtmlHelper<TController>(TController controller)
            where TController : Controller
        {
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.Request.ApplicationPath).Returns(@"/");
            httpContext.Setup(c => c.Response.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

            var routeData = new RouteData();
            var requestContext = new RequestContext(httpContext.Object, routeData);
            var controllerContext = new ControllerContext(requestContext, controller);

            var viewContext = new Mock<ViewContext>();
            viewContext.Setup(vc => vc.Controller).Returns(controller);
            viewContext.Setup(vc => vc.View).Returns(new RazorView(controllerContext, "TestView", "Layout", false, new string[] { }));
            viewContext.Setup(vc => vc.ViewData).Returns(new ViewDataDictionary());
            viewContext.Setup(vc => vc.TempData).Returns(new TempDataDictionary());
            viewContext.Setup(vc => vc.Writer).Returns(new StringWriter(new StringBuilder()));
            viewContext.Setup(vc => vc.RouteData).Returns(routeData);
            viewContext.Setup(vc => vc.HttpContext).Returns(httpContext.Object);
            viewContext.Setup(vc => vc.ClientValidationEnabled).Returns(false);
            viewContext.Setup(vc => vc.UnobtrusiveJavaScriptEnabled).Returns(false);
            viewContext.Setup(vc => vc.FormContext).Returns(new Mock<FormContext>().Object);

            var viewDataContainer = new Mock<IViewDataContainer>();
            viewDataContainer.Setup(vdc => vdc.ViewData).Returns(new ViewDataDictionary());

            var virtualPathProvider = new Mock<VirtualPathProvider>();
            var routeCollection = new RouteCollection(virtualPathProvider.Object);
            routeCollection.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "index", id = UrlParameter.Optional });

            HtmlHelper helper = new HtmlHelper(viewContext.Object, viewDataContainer.Object, routeCollection);
            return helper;
        }
    }
}
