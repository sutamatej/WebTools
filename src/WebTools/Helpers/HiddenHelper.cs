using System;
using System.Linq.Expressions;
using System.Web;
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

    public class Hidden<TModel, TProperty> : Input<TModel, IHidden>, IHidden
    {
        private Expression<Func<TModel, TProperty>> _property;

        public Hidden(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property)
            : base(helper)
        {
            _property = property;
            _attributeLoader = new AttributeLoader<IHidden>(this, _htmlAttributes);
        }

        public override IHidden Disabled(bool disabled)
        {
            return this;
        }

        public override IHidden Readonly(bool @readonly)
        {
            return this;
        }

        public override IHidden Size(int size)
        {
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.HiddenFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface IHidden : IInput<IHidden>, IHtmlString
    {
    }
}
