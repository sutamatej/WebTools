using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public class Label<TModel, TProperty> : HtmlElement<ILabel>, ILabel
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _property;
        private string _labelText;

        public Label(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property, string labelText)
        {
            _helper = helper;
            _property = property;
            _labelText = labelText;
            _attributeLoader = new AttributeLoader<ILabel>(this, _htmlAttributes);
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.LabelFor(_property, _labelText, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ILabel : IHtmlElement<ILabel>, IHtmlString
    {
    }
}
