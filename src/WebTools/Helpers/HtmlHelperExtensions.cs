using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebTools.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static ICheckable CheckBox<TModel>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, Boolean>> property)
        {
            return new CheckBox<TModel>(helper, property);
        }

        public static IDropDownList DropDownList<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            IEnumerable<SelectListItem> items,
            string defaultItem = null)
        {
            return new DropDownList<TModel, TProperty>(helper, property, items, defaultItem);
        }

        public static IForm BeginForm<TController>(
            this HtmlHelper helper,
            Expression<Action<TController>> action,
            FormMethod method)
            where TController : Controller
        {
            return new Form<TController>(helper, action, method);
        }

        public static IHidden Hidden<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new Hidden<TModel, TProperty>(helper, property);
        }

        public static ILabel Label<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            string labelText)
        {
            return new Label<TModel, TProperty>(helper, property, labelText);
        }

        public static IText Password<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new Password<TModel, TProperty>(helper, property);
        }

        public static ICheckable RadioButton<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property,
            TProperty value)
        {
            return new RadioButton<TModel, TProperty>(helper, property, value);
        }

        public static ITextArea TextArea<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new TextArea<TModel, TProperty>(helper, property);
        }

        public static IText TextBox<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property)
        {
            return new TextBox<TModel, TProperty>(helper, property);
        }
    }
}
