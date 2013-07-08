using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public class TextArea<TModel, TProperty> : HtmlElement<ITextArea>, ITextArea
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _property;

        public TextArea(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
        {
            _helper = helper;
            _property = property;
            _attributeLoader = new AttributeLoader<ITextArea>(this, _htmlAttributes);
        }

        public ITextArea Cols(int cols)
        {
            return _attributeLoader.Cols(cols);
        }

        public ITextArea Disabled(bool disabled)
        {
            return _attributeLoader.Disabled(disabled);
        }

        public ITextArea Readonly(bool @readonly)
        {
            return _attributeLoader.Readonly(@readonly);
        }

        public ITextArea Rows(int rows)
        {
            return _attributeLoader.Rows(rows);
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
