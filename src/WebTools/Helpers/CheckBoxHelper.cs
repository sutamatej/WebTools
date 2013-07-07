using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class CheckBoxHelper
    {
        public static ICheckable CheckBox<TModel>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, Boolean>> property)
        {
            return new CheckBox<TModel>(helper, property);
        }
    }

    public class CheckBox<TModel> : Input<TModel, ICheckable>, ICheckable
    {
        private Expression<Func<TModel, Boolean>> _property;

        public CheckBox(HtmlHelper<TModel> helper, Expression<Func<TModel, Boolean>> property)
            : base(helper)
        {
            _property = property;
            _elementInstance = this;
        }

        public ICheckable Checked(bool @checked)
        {
            if (@checked)
                _htmlAttributes.Add(Constants.HtmlAttributes.Checked, Constants.HtmlAttributes.Checked);
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.CheckBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ICheckable : IInput<ICheckable>, IHtmlString
    {
        ICheckable Checked(bool @checked);
    }
}
