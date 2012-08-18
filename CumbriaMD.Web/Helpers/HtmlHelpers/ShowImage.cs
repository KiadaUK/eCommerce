using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CumbriaMD.Web.Helpers.HtmlHelpers
{
    public static class ShowImage
    {

        public static MvcHtmlString Image(this HtmlHelper helper, string url, string altText, string width, string height, string id, string dataBind, object htmlAttributes)
        {
            var builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.Attributes.Add("width", width);
            builder.Attributes.Add("height", height);
            builder.Attributes.Add("id", id);
            builder.Attributes.Add("data-bind", dataBind);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}