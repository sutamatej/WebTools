using System.Web.Mvc;

namespace WebTools.Helpers
{
    public abstract class InputBase<TModel, TElement> : HelperBase<TElement>, IInput<TElement>
    {
        protected HtmlHelper<TModel> _helper;
        protected string _labelText;

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

        // TODO: ?
        //public TElement WithLabel(string labelText)
        //{
        //    _labelText = labelText;
        //    return _elementInstance;
        //}
    }

    public interface IInput<TElement> : IHtmlElement<TElement>
    {
        TElement Disabled(bool disabled);
    }
}
