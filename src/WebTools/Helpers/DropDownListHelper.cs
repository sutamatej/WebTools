using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
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

    public class DropDownList<TModel, TProperty> : HtmlElement<IDropDownList>, IDropDownList
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, TProperty>> _property;
        private IEnumerable<SelectListItem> _items;
        private string _defaultItem;

        public DropDownList(
            HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            IEnumerable<SelectListItem> items,
            string defaultItem)
        {
            _helper = helper;
            _property = property;
            _items = items;
            _defaultItem = defaultItem;
            _elementInstance = this;
        }

        public IDropDownList Disabled(bool disabled)
        {
            if (disabled)
                _htmlAttributes.Add(Constants.HtmlAttributes.Disabled, String.Empty);
            return this;
        }

        public IDropDownList Multiple(bool multiple)
        {
            if (multiple)
                _htmlAttributes.Add(Constants.HtmlAttributes.Multiple, String.Empty);
            return this;
        }

        public IDropDownList Size(int size)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Size, size);
            return this;
        }

        public string ToHtmlString()
        {
            var htmlString = _helper.DropDownListFor(_property, _items, _defaultItem, _htmlAttributes);
            return htmlString.ToString();
        }
    }

    public interface IDropDownList : IHtmlElement<IDropDownList>, IHtmlString
    {
        IDropDownList Disabled(bool disabled);

        IDropDownList Multiple(bool multiple);

        IDropDownList Size(int size);
    }
}
