using System.Collections.Generic;
using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class AttributeLoaderTests
    {
        [Fact]
        public void Attribute_loader_adds_class_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Class("some-class");
            Assert.Equal("some-class", attributes["class"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_id_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Id("some-id");
            Assert.Equal("some-id", attributes["id"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_checked_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Checked(true);
            Assert.Equal("checked", attributes["checked"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_disabled_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Disabled(true);
            Assert.Equal("", attributes["disabled"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_readonly_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Readonly(true);
            Assert.Equal("", attributes["readonly"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_multiple_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Multiple(true);
            Assert.Equal("", attributes["multiple"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_size_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Size(5);
            Assert.Equal(5, attributes["size"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_target_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Target(Enums.ActionTarget.Blank);
            Assert.Equal("_blank", attributes["target"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_cols_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Cols(7);
            Assert.Equal(7, attributes["cols"]);
            Assert.IsType<ElementTestInstance>(result);
        }

        [Fact]
        public void Attribute_loader_adds_rows_attribute()
        {
            var attributes = new Dictionary<string, object>();
            var loader = new AttributeLoader<ElementTestInstance>(new ElementTestInstance(), attributes);
            var result = loader.Rows(3);
            Assert.Equal(3, attributes["rows"]);
            Assert.IsType<ElementTestInstance>(result);
        }
    }

    public class ElementTestInstance
    {
    }
}
