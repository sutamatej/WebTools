using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class CheckBoxHelper
    {
        public static ICheckBox CheckBox<TModel>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, Boolean>> property)
        {
            return new CheckBox<TModel>(helper, property);
        }
    }

    public class CheckBox<TModel> : InputBase<TModel, ICheckBox>, ICheckBox
    {
        private Expression<Func<TModel, Boolean>> _property;

        public CheckBox(HtmlHelper<TModel> helper, Expression<Func<TModel, Boolean>> property)
            : base(helper)
        {
            _property = property;
            _elementInstance = this;
        }

        public ICheckBox Checked(bool @checked)
        {
            if (@checked)
                _htmlAttributes.Add(Constants.Checked, Constants.Checked);
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.CheckBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ICheckBox : IInput<ICheckBox>, IHtmlString
    {
        ICheckBox Checked(bool @checked);
    }
}
