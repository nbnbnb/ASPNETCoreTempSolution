using BasicSite.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSite.Helpers.TagHelpers
{
    /// <summary>
    /// 约定将会进行 Pascal-cased 方式进行转换 http://c2.com/cgi/wiki?KebabCase  lower kebab case
    /// 此处转换为 website-information
    /// </summary>
    public class WebsiteInformationTagHelper : TagHelper
    {
        /// <summary>
        /// 标签中添加 info 属性，不区分大小写
        /// 例如或者绑定一个视图对象
        /* <website-information info="new WebsiteContext {
                                            Version = new Version(1, 3),
                                            CopyrightYear = 1638,
                                            Approved = true,
                                            TagsToShow = 131 }" />
                                            **/
        /// </summary>
        public WebsiteContext Info { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";

            output.Content.SetHtmlContent(
               $@"<ul><li><strong>Version:</strong> {Info.Version}</li>
                <li><strong>Copyright Year:</strong> {Info.CopyrightYear}</li>
                <li><strong>Approved:</strong> {Info.Approved}</li>
                <li><strong>Number of tags to show:</strong> {Info.TagsToShow}</li></ul>");

            // 表示可以使用 <website-information></website-information> 和 <website-information/> 模式
            // 如果不指定，则表示只能使用 <website-information></website-information> 模式
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
