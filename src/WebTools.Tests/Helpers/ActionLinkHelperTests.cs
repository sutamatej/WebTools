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
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(4), "Get").ToHtmlString();
            Assert.Equal("<a href=\"/ActionLinkTest/Get/4\">Get</a>", result);
        }

        [Fact]
        public void Action_link_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(7), "text").Class("test-class").ToHtmlString();
            Assert.Equal("<a class=\"test-class\" href=\"/ActionLinkTest/Get/7\">text</a>", result);
        }

        [Fact]
        public void Action_link_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(3), "something").Id("test-id").ToHtmlString();
            Assert.Equal("<a href=\"/ActionLinkTest/Get/3\" id=\"test-id\">something</a>", result);
        }

        [Fact]
        public void Action_link_helper_renders_rel_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(1), "aaa").Rel("text").ToHtmlString();
            Assert.Equal("<a href=\"/ActionLinkTest/Get/1\" rel=\"text\">aaa</a>", result);
        }

        [Fact]
        public void Action_link_helper_renders_target_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(10), "asdf").Target(Enums.ActionTarget.Top).ToHtmlString();
            Assert.Equal("<a href=\"/ActionLinkTest/Get/10\" target=\"_top\">asdf</a>", result);
        }

        [Fact]
        public void Action_link_helper_renders_data_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(10), "me").Data("superhero", "Batman").ToHtmlString();
            Assert.Equal("<a data-superhero=\"Batman\" href=\"/ActionLinkTest/Get/10\">me</a>", result);
        }

        [Fact]
        public void Action_link_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new ActionLinkTestController());
            var result = helper.ActionLink<ActionLinkTestController>(c => c.Get(17), "fdsa").Class("test-class").Target(Enums.ActionTarget.Blank).Rel("some rel").Id("test-id").ToHtmlString();
            Assert.Equal("<a class=\"test-class\" href=\"/ActionLinkTest/Get/17\" id=\"test-id\" rel=\"some rel\" target=\"_blank\">fdsa</a>", result);
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
