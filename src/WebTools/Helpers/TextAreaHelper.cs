using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class TextAreaHelper
    {
        public static ITextArea TextArea<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new TextArea<TModel, TProperty>(helper, property);
        }
    }

    public class TextArea<TModel, TProperty> : HtmlElement<ITextArea>, ITextArea
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _property;

        public TextArea(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
        {
            _helper = helper;
            _property = property;
            _elementInstance = this;
        }

        public ITextArea Cols(int cols)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Cols, cols);
            return this;
        }

        public ITextArea Disabled(bool disabled)
        {
            if (@disabled)
                _htmlAttributes.Add(Constants.HtmlAttributes.Disabled, String.Empty);
            return this;
        }

        public ITextArea Readonly(bool @readonly)
        {
            if (@readonly)
                _htmlAttributes.Add(Constants.HtmlAttributes.Readonly, String.Empty);
            return this;
        }

        public ITextArea Rows(int rows)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Rows, rows);
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.TextAreaFor(_property, _htmlAttributes);
            return htmlString.ToHtmlString();
        }
    }

    public interface ITextArea : IHtmlElement<ITextArea>, IHtmlString
    {
        ITextArea Cols(int cols);

        ITextArea Disabled(bool disabled);

        ITextArea Readonly(bool @readonly);

        ITextArea Rows(int rows);
    }
}
