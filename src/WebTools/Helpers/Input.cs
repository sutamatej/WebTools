using System.Web.Mvc;

namespace WebTools.Helpers
{
    public abstract class Input<TModel, TElement> : HtmlElement<TElement>
    {
        protected HtmlHelper<TModel> _helper;

        public Input(HtmlHelper<TModel> helper)
        {
            _helper = helper;
        }
    }

    public interface IInput<TElement> : IHtmlElement<TElement>
    {
        TElement Disabled(bool disabled);

        TElement Readonly(bool @readonly);

        TElement Size(int size);
    }
}
