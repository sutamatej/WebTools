using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class PasswordHelperTests
    {
        [Fact]
        public void Password_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).ToHtmlString();
            Assert.Equal("<input id=\"Password\" name=\"Password\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Class("test-class").ToHtmlString();
            Assert.Equal("<input class=\"test-class\" id=\"Password\" name=\"Password\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Id("test-id").ToHtmlString();
            Assert.Equal("<input id=\"test-id\" name=\"Password\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_data_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Data("superhero", "Green Lantern").ToHtmlString();
            Assert.Equal("<input data-superhero=\"Green Lantern\" id=\"Password\" name=\"Password\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Disabled(true).ToHtmlString();
            Assert.Equal("<input disabled=\"\" id=\"Password\" name=\"Password\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_readonly_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Readonly(true).ToHtmlString();
            Assert.Equal("<input id=\"Password\" name=\"Password\" readonly=\"\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_renders_size_attribute()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Size(5).ToHtmlString();
            Assert.Equal("<input id=\"Password\" name=\"Password\" size=\"5\" type=\"password\" />", result);
        }

        [Fact]
        public void Password_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(new PasswordTestModel());
            var result = helper.Password(m => m.Password).Size(7).Class("test-class").Disabled(true).Readonly(true).Id("test-id").ToHtmlString();
            Assert.Equal("<input class=\"test-class\" disabled=\"\" id=\"test-id\" name=\"Password\" readonly=\"\" size=\"7\" type=\"password\" />", result);
        }
    }

    public class PasswordTestModel
    {
        public string Password { get; set; }
    }
}
