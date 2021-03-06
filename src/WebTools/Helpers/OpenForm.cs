﻿using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebTools.Routing;

namespace WebTools.Helpers
{
    public class OpenForm<TController> : HtmlElement<IForm>, IForm
        where TController : Controller
    {
        private HtmlHelper _helper;
        private Expression<Action<TController>> _action;
        private FormMethod _method;

        public OpenForm(HtmlHelper helper, Expression<Action<TController>> action, FormMethod method)
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
            var route = new WebRoute<TController>(_action);
            var formTag = new TagBuilder(Constants.HtmlElements.Form);
            //var urlHelper = new UrlHelper(_helper.ViewContext.RequestContext);
            //var url = urlHelper.Action(route.Action, route.Controller);
            //formTag.MergeAttribute(Constants.HtmlAttributes.Action, url);
            formTag.MergeAttribute(Constants.HtmlAttributes.Action, String.Format("{0}/{1}", route.Controller, route.Action));
            formTag.MergeAttribute(Constants.HtmlAttributes.Method, HtmlHelper.GetFormMethodString(_method));
            formTag.MergeAttributes(_htmlAttributes);
            return formTag.ToString(TagRenderMode.StartTag);
        }
    }

    public interface IForm : IHtmlElement<IForm>, IHtmlString
    {
        IForm Target(Enums.ActionTarget target);
    }
}
