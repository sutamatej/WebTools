using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class HiddenHelper
    {
        public static IHidden Hidden<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new Hidden<TModel, TProperty>(helper, property);
        }
    }

    public class Hidden<TModel, TProperty> : InputBase<TModel, IHidden>, IHidden
    {
        private Expression<Func<TModel, TProperty>> _property;

        public Hidden(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _elementInstance = this;
        }

        public override string ToString()
        {
            var htmlString = _helper.HiddenFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface IHidden : IInput<IHidden>
    {
    }
}
