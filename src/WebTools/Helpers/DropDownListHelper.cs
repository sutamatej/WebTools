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
            _attributeLoader = new AttributeLoader<IDropDownList>(this, _htmlAttributes);
        }

        public IDropDownList Disabled(bool disabled)
        {
            return _attributeLoader.Disabled(disabled);
        }

        public IDropDownList Multiple(bool multiple)
        {
            return _attributeLoader.Multiple(multiple);
        }

        public IDropDownList Size(int size)
        {
            return _attributeLoader.Size(size);
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
