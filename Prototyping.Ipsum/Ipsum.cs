using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using NLipsum.Core;

namespace Prototyping.Ipsum
{
    public class Ipsum : IHtmlString
    {
        // @ipsum()
        // @ipsum().Words(1) // word with no HTML
        // @ipsum().Paragraphs(1) // paragraphs with no HTML
        // All below have HTML
        // @ipsum().h1-6(words: 2, attrib: "class") // <h1 attrib>Lorem Ipsum</h1>
        // @ipsum().p(1, attrib: "class") // <p attrib>Lorem Ipsum</h1>
        // @ipsum().ul(2, attrib: "class") // <ul attrib>Lorem Ipsum</li></ul>
        // @ipsum().ul(2, liAttrib: "class") // <ul><li attrib>Lorem Ipsum</li></ul>
        // @ipsum().ul(2, links: bool, attrib: "class", liAttrib: "class") // <ul><li attrib><a href="#">Lorem Ipsum</a></li></ul>
        private readonly HtmlHelper _html;
        private readonly List<string> _ipsum;

        public Ipsum(HtmlHelper html)
        {
            if (html == null)
                throw new ArgumentNullException("html");
            _html = html;
            _ipsum = new List<string>();
        }

        /// <summary>
        /// Gets a number of lorem ipsum words with out HTML formatting
        /// </summary>
        /// <example>To Create: Lorem ipsum dolor sit amet
        /// <code>
        /// @Html.Ipsum().Words(5)
        /// </code>
        /// </example>
        /// <param name="count">Number of words to create.</param>
        /// <returns></returns>
        public Ipsum Words(int count)
        {
            var words = new LipsumGenerator().GenerateWords(count);
            _ipsum.Add(String.Join(" ", words));
            return this;
        }

        /// <summary>
        /// Gets a number of lorem ipsum paragraphs with out HTML formating
        /// </summary>
        /// <example>
        /// To create five paragraphs that will NOT be nested in HTML 'p' tags.
        /// <code>
        /// @Html.Paragraphs(5)
        /// </code>
        /// </example>
        /// <param name="count">Number of paragraphs to create.</param>
        /// <returns></returns>
        public Ipsum Paragraphs(int count)
        {
            var paragraphs = new LipsumGenerator().GenerateParagraphs(count);
            _ipsum.Add(String.Join(" ", paragraphs));
            return this;
        }

        /// <summary>
        /// Gets an h1 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h1 tag containing Lorem Ipsum.
        /// <code>@Html.h1()</code>
        /// </example>
        /// <example>To create an HTML h1 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h1(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h1(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h1", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets an h2 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h2 tag containing Lorem Ipsum.
        /// <code>@Html.h2()</code>
        /// </example>
        /// <example>To create an HTML h2 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h2(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h2(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h2", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets an h3 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h3 tag containing Lorem Ipsum.
        /// <code>@Html.h3()</code>
        /// </example>
        /// <example>To create an HTML h3 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h3(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h3(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h3", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets an h4 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h4 tag containing Lorem Ipsum.
        /// <code>@Html.h4()</code>
        /// </example>
        /// <example>To create an HTML h4 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h4(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h4(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h4", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets an h5 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h5 tag containing Lorem Ipsum.
        /// <code>@Html.h5()</code>
        /// </example>
        /// <example>To create an HTML h5 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h5(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h5(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h5", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets an h6 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h6 tag containing Lorem Ipsum.
        /// <code>@Html.h6()</code>
        /// </example>
        /// <example>To create an HTML h6 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h6(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public Ipsum h6(int wordCount = 2, object htmlAttributes = null)
        {
            CreateWordsHtmlIpsum("h6", wordCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            return this;
        }

        /// <summary>
        /// Gets a p element containing lorem ipsum
        /// </summary>
        /// <example>To create 3 paragraphs each 6 sentences nested in HTML 'p' tags.
        /// <code>@Html.p(3, 6)</code>
        /// </example>
        /// <param name="paragraphCount"></param>
        /// <param name="sentenceCount"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public Ipsum p(int paragraphCount = 1, int sentenceCount = 5, object htmlAttributes = null)
        {
            for (int i = 0; i < paragraphCount; i++)
            {
                CreateParagraphHtmlIpsum("p", sentenceCount, htmlAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : null);
            }
            return this;
        }

        /// <summary>
        /// Gets a ul element containing lorem ipsum
        /// </summary>
        /// <example>To create a unordered list of Lorem Ipusm nested in HTML 'ul' tags.<code>@Html.ul()</code></example>
        /// <param name="listCount">Number of list items to create</param>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="links">List item will contain a link, ex: href="#"</param>
        /// <param name="ulAttributes">ul element attributes</param>
        /// <param name="liAttributes">li element attributes</param>
        /// <returns></returns>
        public Ipsum ul(int listCount = 5, int wordCount = 2, bool links = false, object ulAttributes = null, object liAttributes = null)
        {
            return CreateListHTMLIpsum("ul", "li", listCount, links, liAttributes, wordCount, ulAttributes);
        }

        /// <summary>
        /// Gets a ol element containing lorem ipsum
        /// </summary>
        /// <example>To create a unordered list of Lorem Ipusm nested in HTML 'ol' tags.<code>@Html.ol()</code></example>
        /// <param name="listCount">Number of list items to create</param>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="links">List item will contain a link, ex: href="#"</param>
        /// <param name="olAttributes">ol element attributes</param>
        /// <param name="liAttributes">li element attributes</param>
        /// <returns></returns>
        public Ipsum ol(int listCount = 5, int wordCount = 2, bool links = false, object olAttributes = null, object liAttributes = null)
        {
            return CreateListHTMLIpsum("ol", "li", listCount, links, liAttributes, wordCount, olAttributes);
        }

        /// <summary>
        /// Gets a static set of HTML paragraphs that resemble a blog post. (500 words with links and strong tags)
        /// </summary>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public Ipsum BlogPost()
        {
            _ipsum.Add(@"<p>Lorem ipsum dolor sit amet, <strong>vim te tritani prodesset</strong> forensibus? Et vel justo simul, vix mutat impedit te, nam quas aliquip contentiones at? Legendos reprehendunt pro et. Vis decore tritani theophrastus id.</p><p>An nam propriae repudiare, mei duis inermis nominavi in? Duo cu scripta salutandi splendide, est an veniam <strong>disputando eloquentiam!</strong> Sit ut tale nusquam abhorreant, quando accumsan elaboraret an duo. In fugit abhorreant nam, mea cu errem essent oblique, an wisi vocibus eam. Iisque oblique torquatos per at, sea commodo malorum <a href=""#"">concludaturque</a> ut?</p><p>No pri vero pertinax! Eu ius clita definitionem? Ne quo labores nominavi, omnes apeirian salutandi te usu. Nec ferri iudico ne!</p><p>Ea ius veri laboramus. Nec an alia eripuit, pri error honestatis ei, nihil audiam id vel. Minim ancillae ad usu. Est omnes nominavi gloriatur cu, minim dissentiunt an ius. Legimus blandit eu sea, corpora apeirian postulant has an.</p><p>Prompta vivendo an mei. Eu mel utroque suscipiantur, perpetua oportere et vel. Qui te omnesque tincidunt. Vix utroque theophrastus et. Amet intellegam persequeris vix ut, cum eu velit facilisis.  </p><p>Est ut erant utamur voluptatibus, an ignota persecuti duo. Constituto dissentiunt ut mea, et eam discere expetendis reformidans. Eos dico definitiones cu, ius ex amet denique conclusionemque. Pri at unum rebum, pro ut alterum accumsan inimicus.</p><p>Vix id mnesarchum vituperata scripserit, vix ad adhuc maiestatis, eam no sint expetenda. Nec omnium disputando eu, adhuc dictas labitur sed ad! Ex etiam graeco pro. Cu malis elaboraret neglegentur ius, at errem solet vis. Accusata patrioque mei ne, in nonumes theophrastus mea, at his deserunt intellegat voluptaria. Quo cu intellegat instructior, sea tantas mucius legimus te. <em>Ut duo illud nullam reprimique, quaestio suavitate cum no!</em></p><p>Ex vide semper sadipscing vis! Mutat nihil eam at, hinc accusam mei no. Eos laudem mollis pericula ad, ne decore fierent torquatos has. Ea omnis placerat probatus eam, an fabulas comprehensam his, ex diceret perpetua sed.</p><p>Zril nonumes volumus ea cum, his quod ubique suscipiantur an. In mea facete iriure aliquip, quo in qualisque consetetur. Unum vero meliore ne usu. Euismod placerat quaerendum usu at, ut per illud lorem eripuit, ex mea euripidis definitiones. Ei facilis invidunt qui, mea facilis consectetuer id? Sed an officiis percipitur?</p><p>Ad usu antiopam definitionem. Ne eos volutpat forensibus. Est justo offendit neglegentur cu? Dictas explicari adolescens te vix.</p><p>No omnis urbanitas liberavisse mel, an esse atqui vix. Nemore nostrud complectitur eu duo, te nonumy delicata quo, ea pri novum bonorum dissentias. Veri atqui vocent in mea, quis percipitur mel ad, his postea postulant complectitur cu. An per dicunt euismod aliquam, adhuc iudico qui ut, discere apeirian voluptaria sit in. Ei movet delenit pri.</p><p>Per in inciderint dissentiet consequuntur, has sumo solet pertinax in? Ne mei ludus legimus, ius nominati antiopam constituto cu, quot nostrud voluptua quo ad. Eos habeo tractatos ei, sumo sale eos ex? Probo audiam an eam, nobis delicata mel ne? Sanctus scaevola no eos, dolore malorum voluptua vim ut.</p><p>Quo numquam complectitur ut, te pri suas facete, quod postea apeirian vel in. Cu pro vocibus <a href=""#"">oportere accusamus</a>.</p>");
            return this;
        }

        private Ipsum CreateListHTMLIpsum(string outer, string inner, int listCount, bool links, object liAttributes, int wordCount, object ulAttributes)
        {
            TagBuilder element = new TagBuilder(outer);
            for (int i = 0; i < listCount; i++)
            {
                if (links)
                {
                    TagBuilder li = new TagBuilder(inner);
                    li.MergeAttributes(liAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(liAttributes) : null);
                    li.InnerHtml = GetWordsHtmlIpsum("a", wordCount, HtmlHelper.AnonymousObjectToHtmlAttributes(new { href = "#" }));
                    element.InnerHtml += li.ToString();
                }
                else
                {
                    element.InnerHtml += GetWordsHtmlIpsum(inner, wordCount, liAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(liAttributes) : null);
                }
            }
            element.MergeAttributes(ulAttributes != null ? HtmlHelper.AnonymousObjectToHtmlAttributes(ulAttributes) : null);

            _ipsum.Add(element.ToString());
            return this;
        }

        private void CreateParagraphHtmlIpsum(string tag, int sentenceCount, IDictionary<string, object> htmlAttributes = null)
        {
            TagBuilder element = new TagBuilder(tag);
            element.MergeAttributes(htmlAttributes);
            element.InnerHtml = String.Join(" ", new LipsumGenerator().GenerateSentences(sentenceCount));
            _ipsum.Add(element.ToString());
        }

        private void CreateWordsHtmlIpsum(string tag, int wordCount, IDictionary<string, object> htmlAttributes = null)
        {
            _ipsum.Add(GetWordsHtmlIpsum(tag, wordCount, htmlAttributes));
        }

        private string GetWordsHtmlIpsum(string tag, int wordCount, IDictionary<string, object> htmlAttributes = null)
        {
            TagBuilder element = new TagBuilder(tag);
            element.MergeAttributes(htmlAttributes);
            element.InnerHtml = String.Join(" ", new LipsumGenerator().GenerateWords(wordCount));
            return element.ToString();
        }

        private void ValidateSettings()
        {
            if (_ipsum.Count() == 0)
            {
                _ipsum.Add(LipsumGenerator.GenerateHtml(1));
            }
        }

        public override string ToString()
        {
            ValidateSettings();

            return String.Join("", _ipsum.ToArray());
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public void Render()
        {
            var writer = _html.ViewContext.Writer;
            using (var textWriter = new HtmlTextWriter(writer))
            {
                textWriter.Write(ToString());
            }
        }
    }
}