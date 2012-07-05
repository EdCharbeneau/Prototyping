using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Prototyping.Placeholdit
{
    public static class PlaceholditExtension
    {
        /// <summary>
        /// Generates a placeholder image via the http://placehold.it web service
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="textColor"></param>
        /// <param name="format"></param>
        /// <returns>Returns an HTML image element with the specified parameters</returns>
        public static MvcHtmlString Placehold(this HtmlHelper html, int width, int height, string text = null, string backgroundColor = null, string textColor = null, object htmlAttributes = null, ImgFormat format = ImgFormat.GIF)
        {
            var placeholder = new TagBuilder("img");
            var options = new StringBuilder();
            placeholder.MergeAttributes(htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            options.AppendFormat(format == ImgFormat.GIF ? "" : ".{0}", format);
            options.AppendFormat(backgroundColor != null ? "/{0}" : "", backgroundColor);
            options.AppendFormat(textColor != null ? "/{0}" : "", textColor);
            options.AppendFormat(text != null ? "&text={0}" : "", text);
            placeholder.Attributes.Add("src", string.Format("http://placehold.it/{0}x{1}{2}", width, height, options));
            return MvcHtmlString.Create(placeholder.ToString(TagRenderMode.SelfClosing));
        }
    }
}