using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicSite.Helpers.TagHelpers
{
    [HtmlTargetElement("p", Attributes = "www")]
    public class AutoLinkerHttpTagHelper : TagHelper
    {
        /// <summary>
        /// 指定执行顺序
        /// 数字越小先执行
        /// 默认值为 0
        /// </summary>
        public override int Order
        {
            get { return int.MinValue; }
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // This filter must run before the AutoLinkerWwwTagHelper as it searches and replaces http and 
            // the AutoLinkerWwwTagHelper adds http to the markup.

            // 多次执行 output.GetChildContentAsync() 将会获得相同的内容
            // 可以使用 output.GetChildContentAsync(false) 获得最新内容，而不是缓存数据
            // 由于其它的处理程序也会对内容进行修改
            // 此处获取最新数据
            var childContent = output.Content.IsModified ? output.Content.GetContent() :
                    (await output.GetChildContentAsync()).GetContent();

            // Find Urls in the content and replace them with their anchor tag equivalent.
            output.Content.SetHtmlContent(Regex.Replace(
                 childContent,
                     @"\b(?:https?://)(\S+)\b",
                      "<a target=\"_blank\" href=\"$0\">$0</a>"));  // http link version}
        }
    }
}
