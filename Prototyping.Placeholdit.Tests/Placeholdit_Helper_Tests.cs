using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Web.Mvc;
using FluentAssertions;
using System.Web;
using System.Collections;

namespace Prototyping.Placeholdit.Tests
{
    [TestFixture]
    public class Placeholdit_Helper_Tests
    {
        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400"" />";

            //act
            element = html.Placehold(width: 300, height: 400).ToString();

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height_Text()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400&amp;text=Sample"" />";

            //act
            element = html.Placehold(width: 300, height: 400, text: "Sample").ToString();

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height_PNG_Format()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400.PNG"" />";

            //act
            element = html.Placehold(width: 300, height: 400, format: ImgFormat.PNG).ToString();

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height_Color()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400/000000/FFFFFF"" />";

            //act
            element = html.Placehold(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000").ToString();

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height_Color_Text()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400/000000/FFFFFF&amp;text=Sample"" />";

            //act
            element = html.Placehold(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000", text: "Sample").ToString();

            //assert
            element.Should().Be(expected);
        }

        [Test]
        public void Should_Create_Img_Tag_Using_Width_and_Height_Color_Text_Format()
        {
            //arrange
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            string element;
            string expected = @"<img src=""http://placehold.it/300x400.PNG/000000/FFFFFF&amp;text=Sample"" />";

            //act
            element = html.Placehold(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000", text: "Sample", format: ImgFormat.PNG).ToString();

            //assert
            element.Should().Be(expected);
        }

        private class FakeHttpContext : HttpContextBase
        {
            private Dictionary<object, object> _items = new Dictionary<object, object>();
            public override IDictionary Items
            {
                get
                {
                    return _items;
                }
            }
        }

        private class FakeViewDataContainer : IViewDataContainer
        {
            private ViewDataDictionary _viewData = new ViewDataDictionary();
            public ViewDataDictionary ViewData
            {
                get
                {
                    return _viewData;
                }
                set
                {
                    _viewData = value;
                }
            }
        }
    }
}