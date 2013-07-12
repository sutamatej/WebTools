using System.Collections.Generic;

namespace WebTools.Helpers
{
    public abstract class HtmlElement<TElement> : IHtmlElement<TElement>
    {
        protected IDictionary<string, object> _htmlAttributes;
        protected AttributeLoader<TElement> _attributeLoader;

        public HtmlElement()
        {
            _htmlAttributes = new Dictionary<string, object>();
        }

        public TElement Class(string @class)
        {
            return _attributeLoader.Class(@class);
        }

        public TElement Id(string id)
        {
            return _attributeLoader.Id(id);
        }

        public TElement Data(string name, string value)
        {
            return _attributeLoader.Data(name, value);
        }
    }

    public interface IHtmlElement<TElement>
    {
        TElement Class(string @class);

        TElement Id(string @id);

        TElement Data(string name, string value);
    }
}
