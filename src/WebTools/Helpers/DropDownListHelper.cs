using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebTools.Helpers
{
    public static class DropDownListHelper
    {
        public static IDropDownList DropDownList<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            IEnumerable<SelectListItem> items,
            string defaultItem = null)
        {
            return new DropDownList<TModel, TProperty>(helper, property, items, defaultItem);
        }
    }

    public class DropDownList<TModel, TProperty> : InputBase<TModel, IDropDownList>, IDropDownList
    {
        private Expression<Func<TModel, TProperty>> _property;
        private IEnumerable<SelectListItem> _items;
        private string _defaultItem;

        public DropDownList(
            HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            IEnumerable<SelectListItem> items,
            string defaultItem)
            : base(helper)
        {
            _property = property;
            _items = items;
            _defaultItem = defaultItem;
            _elementInstance = this;
        }

        public override string ToString()
        {
            var htmlString = _helper.DropDownListFor(_property, _items, _defaultItem, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface IDropDownList : IInput<IDropDownList>
    {

    }
}
