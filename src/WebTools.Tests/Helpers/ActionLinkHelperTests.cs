using System.Web.Mvc;
using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class ActionLinkHelperTests
    {
        [Fact]
        public void Action_link_helper_renders_html()
        {
            var controller = new ActionLinkTestController();
            var helper = HtmlHelperBuilder.GetSimpleHtmlHelper(controller);
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(4), "Get").ToHtmlString();
            Assert.Equal("", result);
        }
    }

    public class ActionLinkTestModel
    {
    }

    public class ActionLinkTestController : Controller
    {
        public ActionResult Get(int id)
        {
            return null;
        }
    }
}
