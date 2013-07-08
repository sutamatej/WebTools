using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public class Password<TModel, TProperty> : Input<TModel, IText>, IText
    {
        private Expression<Func<TModel, TProperty>> _property;

        public Password(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _attributeLoader = new AttributeLoader<IText>(this, _htmlAttributes);
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.PasswordFor(_property, _htmlAttributes);
            return htmlString.ToHtmlString();
        }
    }
}
