using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class CheckBoxHelperTests
    {
        [Fact]
        public void Checkbox_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).ToString();
            Assert.Equal("<input checked=\"checked\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }

        [Fact]
        public void Checkbox_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).Class("test-class").ToString();
            Assert.Equal("<input checked=\"checked\" class=\"test-class\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }

        [Fact]
        public void Checkbox_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).Id("test-id").ToString();
            Assert.Equal("<input checked=\"checked\" id=\"test-id\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }

        [Fact]
        public void Checkbox_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).Disabled(true).ToString();
            Assert.Equal("<input checked=\"checked\" disabled=\"disabled\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }

        [Fact]
        public void Checkbox_helper_renders_checked_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).Checked(true).ToString();
            Assert.Equal("<input checked=\"checked\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }

        [Fact]
        public void Checkbox_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CheckBoxTestModel { SomeProperty = true });
            var result = helper.CheckBox(m => m.SomeProperty).Class("test-class").Id("test-id").Checked(true).Disabled(true).ToString();
            Assert.Equal("<input checked=\"checked\" class=\"test-class\" disabled=\"disabled\" id=\"test-id\" name=\"SomeProperty\" type=\"checkbox\" value=\"true\" /><input name=\"SomeProperty\" type=\"hidden\" value=\"false\" />", result);
        }
    }

    public class CheckBoxTestModel
    {
        public bool SomeProperty { get; set; }
    }
}
