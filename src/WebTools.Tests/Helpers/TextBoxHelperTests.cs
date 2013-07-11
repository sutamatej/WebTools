using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class TextBoxHelperTests
    {
        [Fact]
        public void Textbox_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).ToHtmlString();
            Assert.Equal("<input id=\"Text\" name=\"Text\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Class("text-class").ToHtmlString();
            Assert.Equal("<input class=\"text-class\" id=\"Text\" name=\"Text\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Id("text-id").ToHtmlString();
            Assert.Equal("<input id=\"text-id\" name=\"Text\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Disabled(true).ToHtmlString();
            Assert.Equal("<input disabled=\"\" id=\"Text\" name=\"Text\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_renders_readonly_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Readonly(true).ToHtmlString();
            Assert.Equal("<input id=\"Text\" name=\"Text\" readonly=\"\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_renders_size_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Size(5).ToHtmlString();
            Assert.Equal("<input id=\"Text\" name=\"Text\" size=\"5\" type=\"text\" value=\"\" />", result);
        }

        [Fact]
        public void Textbox_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new TextBoxTestModel());
            var result = helper.TextBox(m => m.Text).Class("test-class").Id("test-id").Size(7).Readonly(true).Disabled(true).ToHtmlString();
            Assert.Equal("<input class=\"test-class\" disabled=\"\" id=\"test-id\" name=\"Text\" readonly=\"\" size=\"7\" type=\"text\" value=\"\" />", result);
        }
    }

    public class TextBoxTestModel
    {
        public string Text { get; set; }
    }
}
