using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class TextBoxHelper
    {
        public static IText TextBox<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new TextBox<TModel, TProperty>(helper, property);
        }
    }

    public class TextBox<TModel, TProperty> : Input<TModel, IText>, IText
    {
        private Expression<Func<TModel, TProperty>> _property;

        public TextBox(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _attributeLoader = new AttributeLoader<IText>(this, _htmlAttributes);
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.TextBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface IText : IInput<IText>, IHtmlString
    {
    }
}
