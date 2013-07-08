using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class RadioButtonHelperTests
    {
        [Fact]
        public void Radio_button_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.Second).ToHtmlString();
            Assert.Equal("<input id=\"Value\" name=\"Value\" type=\"radio\" value=\"Second\" />", result);
        }

        [Fact]
        public void Radio_button_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.First).Class("test-class").ToHtmlString();
            Assert.Equal("<input checked=\"checked\" class=\"test-class\" id=\"Value\" name=\"Value\" type=\"radio\" value=\"First\" />", result);
        }

        [Fact]
        public void Radio_button_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.Third).Id("test-id").ToHtmlString();
            Assert.Equal("<input id=\"test-id\" name=\"Value\" type=\"radio\" value=\"Third\" />", result);
        }

        [Fact]
        public void Radio_button_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.Second).Disabled(true).ToHtmlString();
            Assert.Equal("<input disabled=\"\" id=\"Value\" name=\"Value\" type=\"radio\" value=\"Second\" />", result);
        }

        [Fact]
        public void Radio_button_helper_renders_checked_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.Third).Checked(true).ToHtmlString();
            Assert.Equal("<input checked=\"checked\" id=\"Value\" name=\"Value\" type=\"radio\" value=\"Third\" />", result);
        }

        [Fact]
        public void Radio_button_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new RadioButtonTestModel());
            var result = helper.RadioButton(m => m.Value, RadioButtonTestEnum.First).Id("some-id").Disabled(true).Class("some-class").Checked(true).ToHtmlString();
            Assert.Equal("<input checked=\"checked\" class=\"some-class\" disabled=\"\" id=\"some-id\" name=\"Value\" type=\"radio\" value=\"First\" />", result);
        }
    }

    public class RadioButtonTestModel
    {
        public RadioButtonTestEnum Value { get; set; }
    }

    public enum RadioButtonTestEnum
    {
        First,
        Second,
        Third
    }
}
