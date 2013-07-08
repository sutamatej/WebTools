using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class CloseFormHelperTests
    {
        [Fact]
        public void Close_form_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new CloseFormTestModel());
            var result = helper.CloseForm().ToHtmlString();
            Assert.Equal("</form>", result);
        }
    }

    public class CloseFormTestModel
    {
    }
}
