using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSite.Helpers.TagHelpers
{
    /// <summary>
    /// 匹配指定属性的标签 
    /// <bold> Is this bold?</bold> 这种预定格式不会被匹配到
    /// 如果要匹配 <bold>，则需要添加 [HtmlTargetElement("bold")]
    /// 注意，不能使用 [HtmlTargetElement("bold",Attributes = "bold")] 这种格式逻辑且
    /// 添加多个 HtmlTargetElement 表示逻辑或
    /// 多个用 , 进行分割
    /// 可以使用 address-info* 这种匹配模式
    /// </summary>
    [HtmlTargetElement(Attributes = "bold")]
    [HtmlTargetElement("bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
        }
    }
}
