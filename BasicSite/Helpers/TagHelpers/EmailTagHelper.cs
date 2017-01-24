using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSite.Helpers.TagHelpers
{
    /// <summary>
    /// 使用命名前缀进行标签匹配
    /// 例如 Email TagHelper 将会匹配  <email> 标签
    /// 如果不用这种约定，也可以进行显式设定，例如  [HtmlTargetElement("emailkk")]
    /// </summary>
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "contoso.com";

        // Can be passed via <email mail-to="..." />. 
        // Pascal case gets translated into lower-kebab-case.
        // 通过标签的 mail-to 属性进行设置
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }

        /// <summary>
        /// 优先使用异步模式
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";                                 // Replaces <email> with <a> tag
            TagHelperContent content = await output.GetChildContentAsync();  // 获得标签中的内容
            string target = content.GetContent() + "@async-" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
