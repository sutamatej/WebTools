using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class RadioButtonHelper
    {
        public static ICheckable RadioButton<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            TProperty value)
        {
            return new RadioButton<TModel, TProperty>(helper, property, value);
        }
    }

    public class RadioButton<TModel, TProperty> : Input<TModel, ICheckable>, ICheckable
    {
        private Expression<Func<TModel, TProperty>> _property;
        private TProperty _value;

        public RadioButton(
            HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            TProperty value)
            : base(helper)
        {
            _property = property;
            _value = value;
            _attributeLoader = new AttributeLoader<ICheckable>(this, _htmlAttributes);
        }

        public ICheckable Checked(bool @checked)
        {
            return _attributeLoader.Checked(@checked);
        }

        public override ICheckable Readonly(bool @readonly)
        {
            return this;
        }

        public override ICheckable Size(int size)
        {
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.RadioButtonFor(_property, _value, _htmlAttributes);
            return htmlString.ToString();
        }
    }
}
