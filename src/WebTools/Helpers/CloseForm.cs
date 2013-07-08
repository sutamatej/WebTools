using System.Web;
using System.Web.Mvc;

namespace WebTools.Helpers
{
    public class CloseForm : IHtmlString
    {
        public CloseForm()
        {
        }

        public string ToHtmlString()
        {
            var formTag = new TagBuilder("form");
            return formTag.ToString(TagRenderMode.EndTag);
        }
    }
}
