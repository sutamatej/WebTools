using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class LabelHelperTests
    {
        [Fact]
        public void Label_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new LabelTestModel { SomeProperty = "abcd" });
            var result = helper.Label(m => m.SomeProperty, "a label").ToHtmlString();
            Assert.Equal("<label for=\"SomeProperty\">a label</label>", result);
        }

        [Fact]
        public void Label_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new LabelTestModel { SomeProperty = "xyz" });
            var result = helper.Label(m => m.SomeProperty, "label").Class("test-class").ToHtmlString();
            Assert.Equal("<label class=\"test-class\" for=\"SomeProperty\">label</label>", result);
        }

        [Fact]
        public void Label_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new LabelTestModel { SomeProperty = "ghj" });
            var result = helper.Label(m => m.SomeProperty, "test").Id("test-id").ToHtmlString();
            Assert.Equal("<label for=\"SomeProperty\" id=\"test-id\">test</label>", result);
        }

        [Fact]
        public void Label_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new LabelTestModel { SomeProperty = "qwe" });
            var result = helper.Label(m => m.SomeProperty, "more testing").Id("test-id").Class("test-class").ToHtmlString();
            Assert.Equal("<label class=\"test-class\" for=\"SomeProperty\" id=\"test-id\">more testing</label>", result);
        }
    }

    public class LabelTestModel
    {
        public string SomeProperty { get; set; }
    }
}
