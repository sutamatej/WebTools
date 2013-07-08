using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebTools.Routing;

namespace WebTools.Helpers
{
    public static class FormHelper
    {
        public static IForm BeginForm<TController>(
            this HtmlHelper helper,
            Expression<Action<TController>> action,
            FormMethod method)
            where TController : Controller
        {
            return new Form<TController>(helper, action, method);
        }
    }

    public class Form<TController> : HtmlElement<IForm>, IForm
        where TController : Controller
    {
        private HtmlHelper _helper;
        private Expression<Action<TController>> _action;
        private FormMethod _method;

        public Form(HtmlHelper helper, Expression<Action<TController>> action, FormMethod method)
        {
            _helper = helper;
            _action = action;
            _method = method;
            _attributeLoader = new AttributeLoader<IForm>(this, _htmlAttributes);
        }

        public IForm Target(Enums.ActionTarget target)
        {
            return _attributeLoader.Target(target);
        }

        public string ToHtmlString()
        {
            var webRoute = new WebRoute<TController>(_action);
            return _helper.BeginForm(webRoute.Action, webRoute.Controller, webRoute.Params, _method, _htmlAttributes).ToString();
        }
    }

    public interface IForm : IHtmlElement<IForm>, IHtmlString
    {
        IForm Target(Enums.ActionTarget target);
    }
}
