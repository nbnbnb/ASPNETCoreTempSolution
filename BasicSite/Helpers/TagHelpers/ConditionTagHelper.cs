using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSite.Helpers.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement(Attributes = nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        /// <summary>
        /// 在视图中绑定一个 bool 类型属性        
        /// </summary>
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
            {
                output.SuppressOutput();  // 不输出标签内容
            }
        }
    }
}
