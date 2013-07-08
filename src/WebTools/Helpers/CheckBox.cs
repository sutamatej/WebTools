using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public class CheckBox<TModel> : Input<TModel, ICheckable>, ICheckable
    {
        private Expression<Func<TModel, Boolean>> _property;

        public CheckBox(HtmlHelper<TModel> helper, Expression<Func<TModel, Boolean>> property)
            : base(helper)
        {
            _property = property;
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
            var htmlString = _helper.CheckBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ICheckable : IInput<ICheckable>, IHtmlString
    {
        ICheckable Checked(bool @checked);
    }
}
