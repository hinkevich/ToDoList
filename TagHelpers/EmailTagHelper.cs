using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ToDoList.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "gmail.com";

        [HtmlAttributeName("recipient")]
        public string MailTo { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
