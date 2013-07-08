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

        public virtual TElement Disabled(bool disabled)
        {
            return _attributeLoader.Disabled(disabled);
        }

        public virtual TElement Readonly(bool @readonly)
        {
            return _attributeLoader.Readonly(@readonly);
        }

        public virtual TElement Size(int size)
        {
            return _attributeLoader.Size(size);
        }
    }

    public interface IInput<TElement> : IHtmlElement<TElement>
    {
        TElement Disabled(bool disabled);

        TElement Readonly(bool @readonly);

        TElement Size(int size);
    }
}
