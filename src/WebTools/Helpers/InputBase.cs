using System.Web.Mvc;

namespace WebTools.Helpers
{
    public abstract class InputBase<TModel, TElement> : HelperBase<TElement>, IInput<TElement>
    {
        protected HtmlHelper<TModel> _helper;

        public InputBase(HtmlHelper<TModel> helper)
        {
            _helper = helper;
        }

        public TElement Disabled(bool disabled)
        {
            if (disabled)
                _htmlAttributes.Add(Constants.Disabled, Constants.Disabled);
            return _elementInstance;
        }
    }

    public interface IInput<TElement> : IHtmlElement<TElement>
    {
        TElement Disabled(bool disabled);
    }
}
