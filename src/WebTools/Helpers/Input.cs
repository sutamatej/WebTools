using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebTools.Helpers
{
    public abstract class Input<TModel, TElement> : HtmlElement<TElement>, IInput<TElement>
    {
        protected HtmlHelper<TModel> _helper;

        public Input(HtmlHelper<TModel> helper)
        {
            _helper = helper;
        }

        public TElement Disabled(bool disabled)
        {
            if (disabled)
                _htmlAttributes.Add(Constants.HtmlAttributes.Disabled, Constants.HtmlAttributes.Disabled);
            return _elementInstance;
        }

        public TElement Readonly(bool @readonly)
        {
            if (@readonly)
                _htmlAttributes.Add(Constants.HtmlAttributes.Readonly, String.Empty);
            return _elementInstance;
        }

        public TElement Size(int size)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Size, size);
            return _elementInstance;
        }

        //public TElement Value(TProperty value)
        //{
        //    _htmlAttributes.Add(Constants.Value, value);
        //    return _elementInstance;
        //}
    }

    public interface IInput<TElement> : IHtmlElement<TElement>
    {
        TElement Disabled(bool disabled);

        TElement Readonly(bool @readonly);

        TElement Size(int size);

        //TElement Value(TProperty value);
    }
}
