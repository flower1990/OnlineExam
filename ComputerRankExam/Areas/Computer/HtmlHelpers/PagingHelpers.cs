using ComputerRankExam.Areas.Computer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Computer.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
           PagingInfo pagingInfo,
           Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();


            TagBuilder tag1 = shaespan(pagingInfo.TotalItems + "条/" + pagingInfo.TotalPages + "页");
            result.Append(tag1.ToString());
            if (pagingInfo.CurrentPage > 1)
            {
                result.Append(aTag("首页", pageUrl(1)).ToString());
                result.Append(aTag("上一页", pageUrl(pagingInfo.CurrentPage - 1).ToString()).ToString());
            }
            else
            {
                result.Append(shaespan("上一页").ToString());
            }
            if (pagingInfo.CurrentPage < pagingInfo.TotalPages)
            {
                result.Append(aTag("下一页", pageUrl(pagingInfo.CurrentPage + 1).ToString()));
                result.Append(aTag("尾页", pageUrl(pagingInfo.TotalPages).ToString()));
            }
            else
            {
                result.Append(shaespan("尾页").ToString());
            }

            result.Append(shaespan("转到").ToString());

            TagBuilder tagsle = new TagBuilder("select");
            tagsle.AddCssClass("css_yema2");
            tagsle.MergeAttribute("name", "sel_page");
            tagsle.MergeAttribute("onChange", "javascript:location=this.options[this.selectedIndex].value;");

            StringBuilder optionsb = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder optag = new TagBuilder("option");
                optag.MergeAttribute("value", pageUrl(i));
                if (i == pagingInfo.CurrentPage)
                {
                    optag.MergeAttribute("selected", "selected");
                }
                optag.InnerHtml = i.ToString();
                optionsb.AppendLine(optag.ToString());

            }
            tagsle.InnerHtml = optionsb.ToString();

            result.Append(tagsle.ToString());
            result.Append("页");
            return MvcHtmlString.Create(result.ToString());
        }
        public static TagBuilder shaespan(string txt)
        {
            TagBuilder tag1 = new TagBuilder("span");
            tag1.AddCssClass("css_yema");
            tag1.MergeAttribute("onMouseOver", "this.className=\"css_yema1\"");
            tag1.MergeAttribute("onMouseOut", "this.className=\"css_yema\"");
            tag1.InnerHtml = txt;
            return tag1;
        }

        public static TagBuilder aTag(string txt, string url)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("href", url);
            tag.InnerHtml = shaespan(txt).ToString();
            return tag;
        }

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName, string controllerName, object routeValue = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string url = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}