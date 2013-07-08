using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class TextAreaHelperTests
    {
        [Fact]
        public void Text_area_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).ToHtmlString();
            Assert.Equal("<textarea cols=\"20\" id=\"Area\" name=\"Area\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Class("test-class").ToHtmlString();
            Assert.Equal("<textarea class=\"test-class\" cols=\"20\" id=\"Area\" name=\"Area\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Id("test-id").ToHtmlString();
            Assert.Equal("<textarea cols=\"20\" id=\"test-id\" name=\"Area\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Disabled(true).ToHtmlString();
            Assert.Equal("<textarea cols=\"20\" disabled=\"\" id=\"Area\" name=\"Area\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_readonly_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Readonly(true).ToHtmlString();
            Assert.Equal("<textarea cols=\"20\" id=\"Area\" name=\"Area\" readonly=\"\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_cols_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Cols(10).ToHtmlString();
            Assert.Equal("<textarea cols=\"10\" id=\"Area\" name=\"Area\" rows=\"2\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_renders_rows_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Rows(3).ToHtmlString();
            Assert.Equal("<textarea cols=\"20\" id=\"Area\" name=\"Area\" rows=\"3\">\r\n</textarea>", result);
        }

        [Fact]
        public void Text_area_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new TextAreaTestModel());
            var result = helper.TextArea(m => m.Area).Rows(4).Class("test-class").Disabled(true).Cols(5).Readonly(true).Id("test-id").ToHtmlString();
            Assert.Equal("<textarea class=\"test-class\" cols=\"5\" disabled=\"\" id=\"test-id\" name=\"Area\" readonly=\"\" rows=\"4\">\r\n</textarea>", result);
        }
    }

    public class TextAreaTestModel
    {
        public string Area { get; set; }
    }
}
