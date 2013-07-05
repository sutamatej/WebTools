using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class TextBoxHelper
    {
        public static ITextBox TextBox<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new TextBox<TModel, TProperty>(helper, property);
        }
    }

    public class TextBox<TModel, TProperty> : Input<TModel, ITextBox>, ITextBox
    {
        private Expression<Func<TModel, TProperty>> _property;

        public TextBox(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _elementInstance = this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.TextBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ITextBox : IInput<ITextBox>, IHtmlString
    {
    }
}
