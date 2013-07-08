using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class PasswordHelper
    {
        public static IText Password<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new Password<TModel, TProperty>(helper, property);
        }
    }

    public class Password<TModel, TProperty> : Input<TModel, IText>, IText
    {
        private Expression<Func<TModel, TProperty>> _property;

        public Password(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _attributeLoader = new AttributeLoader<IText>(this, _htmlAttributes);
        }

        public IText Disabled(bool disabled)
        {
            return _attributeLoader.Disabled(disabled);
        }

        public IText Readonly(bool @readonly)
        {
            return _attributeLoader.Readonly(@readonly);
        }

        public IText Size(int size)
        {
            return _attributeLoader.Size(size);
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.PasswordFor(_property, _htmlAttributes);
            return htmlString.ToHtmlString();
        }
    }
}
