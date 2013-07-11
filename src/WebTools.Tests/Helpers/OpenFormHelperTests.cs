using System.Web.Mvc;
using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class OpenFormHelperTests
    {
        [Fact]
        public void Open_form_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new OpenFormTestModel());
            var result = helper.OpenForm<OpenFormTestController>(c => c.Save(null), FormMethod.Post).ToHtmlString();
            Assert.Equal("<form action=\"OpenFormTest/Save\" method=\"post\">", result);
        }

        [Fact]
        public void Open_form_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new OpenFormTestModel());
            var result = helper.OpenForm<OpenFormTestController>(c => c.Save(null), FormMethod.Post).Class("test-class").ToHtmlString();
            Assert.Equal("<form action=\"OpenFormTest/Save\" class=\"test-class\" method=\"post\">", result);
        }

        [Fact]
        public void Open_form_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new OpenFormTestModel());
            var result = helper.OpenForm<OpenFormTestController>(c => c.Save(null), FormMethod.Post).Id("test-id").ToHtmlString();
            Assert.Equal("<form action=\"OpenFormTest/Save\" id=\"test-id\" method=\"post\">", result);
        }

        [Fact]
        public void Open_form_helper_renders_target_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new OpenFormTestModel());
            var result = helper.OpenForm<OpenFormTestController>(c => c.Save(null), FormMethod.Post).Target(Enums.ActionTarget.Parent).ToHtmlString();
            Assert.Equal("<form action=\"OpenFormTest/Save\" method=\"post\" target=\"_parent\">", result);
        }

        [Fact]
        public void Open_form_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new OpenFormTestModel());
            var result = helper.OpenForm<OpenFormTestController>(c => c.Save(null), FormMethod.Post).Id("test-id").Target(Enums.ActionTarget.Self).Class("test-class").ToHtmlString();
            Assert.Equal("<form action=\"OpenFormTest/Save\" class=\"test-class\" id=\"test-id\" method=\"post\" target=\"_self\">", result);
        }
    }

    public class OpenFormTestModel
    {
    }

    public class OpenFormTestController : Controller
    {
        public ActionResult Save(OpenFormTestModel model)
        {
            return null;
        }
    }
}
