using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Runtime.CompilerServices;
using ToDoList.Models;

namespace ToDoList.TagHelpers
{
    public class ToDoListInformationTagHelper : TagHelper
    {
        public ToDoListInfoContext Info { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "info-section";

            output.Content.SetHtmlContent(
                $@"<ul>
                    <li><strong>Version:</strong> {Info.version}</li>
                    <li><strong>Copyright Year:</strong> {Info.CopyrightDate}</li>
                    <li><strong>Approved:</strong> {Info.Approved}</li>
                    <li><strong>Approved by:</strong> {Info.ApprovedByName}</li>
                    </ul>"
                );
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
