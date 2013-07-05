using System.Collections.Generic;

namespace WebTools.Helpers
{
    public abstract class HtmlElement<TElement> : IHtmlElement<TElement>
    {
        protected IDictionary<string, object> _htmlAttributes;
        protected TElement _elementInstance;

        public HtmlElement()
        {
            _htmlAttributes = new Dictionary<string, object>();
        }

        public TElement Class(string @class)
        {
            _htmlAttributes.Add(Constants.Class, @class);
            return _elementInstance;
        }

        public TElement Id(string id)
        {
            _htmlAttributes.Add(Constants.Id, id);
            return _elementInstance;
        }
    }

    public interface IHtmlElement<TElement>
    {
        TElement Class(string @class);

        TElement Id(string @id);
    }
}
