﻿using System.Collections.Generic;
using System.Web.Mvc;
using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class DropDownListHelperTests
    {
        [Fact]
        public void Dropdown_list_helper_renders_html()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).ToHtmlString();
            Assert.Equal("<select id=\"Value\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_default_option()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList, "default").ToHtmlString();
            Assert.Equal("<select id=\"Value\" name=\"Value\"><option value=\"\">default</option>\r\n<option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_class_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Class("some-class").ToHtmlString();
            Assert.Equal("<select class=\"some-class\" id=\"Value\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_id_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Id("some-id").ToHtmlString();
            Assert.Equal("<select id=\"some-id\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_data_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Data("superhero", "Superman").ToHtmlString();
            Assert.Equal("<select data-superhero=\"Superman\" id=\"Value\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_disabled_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Disabled(true).ToHtmlString();
            Assert.Equal("<select disabled=\"\" id=\"Value\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_multiple_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Multiple(true).ToHtmlString();
            Assert.Equal("<select id=\"Value\" multiple=\"\" name=\"Value\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_renders_size_attribute()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList).Size(5).ToHtmlString();
            Assert.Equal("<select id=\"Value\" name=\"Value\" size=\"5\"><option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }

        [Fact]
        public void Dropdown_list_helper_supports_attribute_combinations()
        {
            var model = new DropDownListTestModel();
            var helper = HtmlHelperBuilder.GetTypedHtmlHelper(model);
            var result = helper.DropDownList(m => m.Value, model.SelectList, "default").Id("test-id").Class("test-class").Disabled(true).Multiple(true).Size(3).ToHtmlString();
            Assert.Equal("<select class=\"test-class\" disabled=\"\" id=\"test-id\" multiple=\"\" name=\"Value\" size=\"3\"><option value=\"\">default</option>\r\n<option value=\"1\">a</option>\r\n<option value=\"2\">b</option>\r\n<option value=\"3\">c</option>\r\n</select>", result);
        }
    }

    public class DropDownListTestModel
    {
        public int Value { get; set; }

        public IEnumerable<SelectListItem> SelectList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "a", Value = "1" },
                    new SelectListItem { Text = "b", Value = "2", Selected = true },
                    new SelectListItem { Text = "c", Value = "3" }
                };
            }
        }
    }
}
