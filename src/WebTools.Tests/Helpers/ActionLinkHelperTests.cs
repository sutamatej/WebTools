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
