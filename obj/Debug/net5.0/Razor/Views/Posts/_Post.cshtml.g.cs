#pragma checksum "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50de9e3db3f2ecb5a198371d164c024484c86abd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts__Post), @"mvc.1.0.view", @"/Views/Posts/_Post.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\james\source\repos\www\Views\_ViewImports.cshtml"
using www;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\james\source\repos\www\Views\_ViewImports.cshtml"
using www.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50de9e3db3f2ecb5a198371d164c024484c86abd", @"/Views/Posts/_Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef621fd50e38106041300085f77523b24bb6487b", @"/Views/_ViewImports.cshtml")]
    public class Views_Posts__Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
  
    var existedSince = (DateTime.Now - Model.Created) switch
    {
        { TotalHours: < 1 } ts => $"{ts.Minutes} minutes ago",
        { TotalDays: < 1 } ts => $"{ts.Hours} hours ago",
        { TotalDays: < 2 } => $"yesterday",
        { TotalDays: < 5 } => $"on {Model.Created.DayOfWeek}",
        var ts => $"{ts.Days} days ago",
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n\r\n    <div class=\"dropdown\">\r\n        <div class=\"dropdown-menu\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 442, "\"", 474, 2);
            WriteAttributeValue("", 460, "menu-", 460, 5, true);
#nullable restore
#line 15 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
WriteAttributeValue("", 465, Model.Id, 465, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50de9e3db3f2ecb5a198371d164c024484c86abd4641", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
                                                         WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <a href=\"#\" class=\"dropdown-item delete-button\" data-toggle=\"modal\" data-target=\"#delete-modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 675, "\"", 709, 3);
            WriteAttributeValue("", 685, "loadDelete(\'", 685, 12, true);
#nullable restore
#line 17 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
WriteAttributeValue("", 697, Model.Id, 697, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 706, "\');", 706, 3, true);
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n        </div>\r\n    </div>\r\n<p>\r\n    ");
#nullable restore
#line 21 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
Write(Model.User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <small>");
#nullable restore
#line 22 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
      Write(existedSince);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n</p>\r\n    <button class=\"btn btn-secondary\" type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 864, "\"", 883, 2);
            WriteAttributeValue("", 869, "menu-", 869, 5, true);
#nullable restore
#line 24 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
WriteAttributeValue("", 874, Model.Id, 874, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\" style=\"display:inline\">\r\n        ...\r\n    </button>\r\n\r\n</div>\r\n");
#nullable restore
#line 29 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
 if (!Model.isDeleted)
        {

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
 if (Model.Content != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"post-content\">");
#nullable restore
#line 33 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
                     Write(Html.Raw(Model.Content.Trim()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 34 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"embed-code\"></div>\r\n<div class=\"attachment-code\"></div>\r\n<input type=\"hidden\" class=\"attachment-code\"");
            BeginWriteAttribute("value", " value=\"", 1286, "\"", 1312, 1);
#nullable restore
#line 37 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
WriteAttributeValue("", 1294, Model.Attachments, 1294, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<div class=\"text-right text-sm-right\">\r\n    <small>\r\n    </small>\r\n</div>\r\n<div class=\"row\">\r\n    <button class=\"col-6\">Like</button>\r\n\r\n    <button class=\"col-6\">Comment</button>\r\n</div>\r\n<div class=\"row\">\r\n\r\n</div>\r\n");
#nullable restore
#line 50 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"

        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<i>This message has been deleted.</i>\r\n");
#nullable restore
#line 55 "C:\Users\james\source\repos\www\Views\Posts\_Post.cshtml"
        }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591