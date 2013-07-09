using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebTools.Routing;

namespace WebTools.Helpers
{
    public class ActionLink<TController> : HtmlElement<IActionLink>, IActionLink
        where TController : Controller
    {
        private HtmlHelper _helper;
        private Expression<Action<TController>> _action;
        private string _linkText;

        public ActionLink(HtmlHelper helper, Expression<Action<TController>> action, string linkText)
        {
            _helper = helper;
            _action = action;
            _linkText = linkText;
            _attributeLoader = new AttributeLoader<IActionLink>(this, _htmlAttributes);
        }

        public IActionLink Rel(string rel)
        {
            return _attributeLoader.Rel(rel);
        }

        public IActionLink Target(Enums.ActionTarget target)
        {
            return _attributeLoader.Target(target);
        }

        public string ToHtmlString()
        {
            var route = new WebRoute<TController>(_action);
            var htmlString = _helper.ActionLink(_linkText, route.Action, route.Controller, route.Params, _htmlAttributes);
            return htmlString.ToHtmlString();
        }
    }

    public interface IActionLink : IHtmlElement<IActionLink>, IHtmlString
    {
        IActionLink Rel(string rel);

        IActionLink Target(Enums.ActionTarget target);
    }
}
