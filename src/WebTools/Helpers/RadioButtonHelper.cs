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
            _elementInstance = this;
        }

        public ICheckable Checked(bool @checked)
        {
            if (@checked)
                _htmlAttributes.Add(Constants.Checked, Constants.Checked);
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.RadioButtonFor(_property, _value, _htmlAttributes);
            return htmlString.ToString();
        }
    }
}
