using System;
using System.Linq;
using System.Web.Mvc;
using System.Web;


namespace Prototyping.Ipsum
{
    public static class IpsumHelper
    {
        /// <summary>
        /// Generates lorem ipsum placeholder text
        /// </summary>
        public static Ipsum Ipsum(this HtmlHelper html)
        {
            return new Ipsum(html);
        }
    }
}