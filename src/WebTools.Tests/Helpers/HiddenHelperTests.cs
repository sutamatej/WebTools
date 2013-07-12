using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class HiddenHelperTests
    {
        [Fact]
        public void Hidden_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new HiddenTestModel { SomeProperty = "test" });
            var result = helper.Hidden(m => m.SomeProperty).ToHtmlString();
            Assert.Equal("<input id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"test\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new HiddenTestModel { SomeProperty = "aaa" });
            var result = helper.Hidden(m => m.SomeProperty).Class("test-class").ToHtmlString();
            Assert.Equal("<input class=\"test-class\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"aaa\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new HiddenTestModel { SomeProperty = "asdf" });
            var result = helper.Hidden(m => m.SomeProperty).Id("test-id").ToHtmlString();
            Assert.Equal("<input id=\"test-id\" name=\"SomeProperty\" type=\"hidden\" value=\"asdf\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_data_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new HiddenTestModel { SomeProperty = "asdf" });
            var result = helper.Hidden(m => m.SomeProperty).Data("superhero","Nightwing").ToHtmlString();
            Assert.Equal("<input data-superhero=\"Nightwing\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"asdf\" />", result);
        }

        [Fact]
        public void Hidden_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new HiddenTestModel { SomeProperty = "qwerty" });
            var result = helper.Hidden(m => m.SomeProperty).Id("test-id").Class("some-class").ToHtmlString();
            Assert.Equal("<input class=\"some-class\" id=\"test-id\" name=\"SomeProperty\" type=\"hidden\" value=\"qwerty\" />", result);
        }
    }

    public class HiddenTestModel
    {
        public string SomeProperty { get; set; }
    }
}
