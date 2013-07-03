using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    public class CheckBox<TModel> : ICheckBox
    {
        private IDictionary<string, object> _htmlAttributes;
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, Boolean>> _property;

        public CheckBox(HtmlHelper<TModel> helper, Expression<Func<TModel, Boolean>> property)
        {
            _htmlAttributes = new Dictionary<string, object>();
            _helper = helper;
            _property = property;
        }

        public ICheckBox Class(string @class)
        {
            _htmlAttributes.Add(Constants.Class, @class);
            return this;
        }

        public ICheckBox Id(string id)
        {
            _htmlAttributes.Add(Constants.Id, id);
            return this;
        }

        public override string ToString()
        {
            var htmlString = _helper.CheckBoxFor(_property, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface ICheckBox
    {
        ICheckBox Class(string @class);

        ICheckBox Id(string @id);
    }
}
