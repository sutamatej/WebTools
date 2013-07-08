using System;
using System.Collections.Generic;

namespace WebTools.Helpers
{
    public class AttributeLoader<TElement>
    {
        private IDictionary<string, object> _htmlAttributes;
        private TElement _elementInstance;
        private IDictionary<Enums.ActionTarget, string> _targets;

        public AttributeLoader(TElement elementInstance, IDictionary<string, object> htmlAttributes)
        {
            _elementInstance = elementInstance;
            _htmlAttributes = htmlAttributes;
            _targets = new Dictionary<Enums.ActionTarget, string>
            {
                { Enums.ActionTarget.Self, Constants.HtmlAttributeValues.Self },
                { Enums.ActionTarget.Blank, Constants.HtmlAttributeValues.Blank },
                { Enums.ActionTarget.Parent, Constants.HtmlAttributeValues.Parent },
                { Enums.ActionTarget.Top, Constants.HtmlAttributeValues.Top }
            };
        }

        public TElement Class(string @class)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Class, @class);
            return _elementInstance;
        }

        public TElement Id(string id)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Id, id);
            return _elementInstance;
        }

        public TElement Checked(bool @checked)
        {
            if (@checked)
                _htmlAttributes.Add(Constants.HtmlAttributes.Checked, Constants.HtmlAttributes.Checked);
            return _elementInstance;
        }

        public TElement Disabled(bool disabled)
        {
            if (disabled)
                _htmlAttributes.Add(Constants.HtmlAttributes.Disabled, String.Empty);
            return _elementInstance;
        }

        public TElement Readonly(bool @readonly)
        {
            if (@readonly)
                _htmlAttributes.Add(Constants.HtmlAttributes.Readonly, String.Empty);
            return _elementInstance;
        }

        public TElement Multiple(bool multiple)
        {
            if (multiple)
                _htmlAttributes.Add(Constants.HtmlAttributes.Multiple, String.Empty);
            return _elementInstance;
        }

        public TElement Size(int size)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Size, size);
            return _elementInstance;
        }

        public TElement Target(Enums.ActionTarget target)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Target, _targets[target]);
            return _elementInstance;
        }

        public TElement Cols(int cols)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Cols, cols);
            return _elementInstance;
        }

        public TElement Rows(int rows)
        {
            _htmlAttributes.Add(Constants.HtmlAttributes.Rows, rows);
            return _elementInstance;
        }
    }
}
