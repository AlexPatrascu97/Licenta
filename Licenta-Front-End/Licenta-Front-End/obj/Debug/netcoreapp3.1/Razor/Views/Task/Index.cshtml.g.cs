#pragma checksum "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24fb3c486ecce731873f2585a9c503410176f101"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_Index), @"mvc.1.0.view", @"/Views/Task/Index.cshtml")]
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
#line 1 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\_ViewImports.cshtml"
using Licenta_Front_End;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\_ViewImports.cshtml"
using Licenta_Front_End.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24fb3c486ecce731873f2585a9c503410176f101", @"/Views/Task/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b44f24061997867f5fddafee9a547c881632ec3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Licenta_Front_End.Models.Task>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
  
	ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
 using (Html.BeginForm("Index", "Task", FormMethod.Get))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<p>\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24fb3c486ecce731873f2585a9c503410176f1014222", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t<input class=\"btn btn-warning\" type=\"submit\" value=\"Search\" />\r\n\t</p>\r\n\t<br>\r\n");
#nullable restore
#line 14 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
Write(Html.TextBox("searching", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<br>\r\n");
#nullable restore
#line 16 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n\r\n<div class=\"table-responsive box\">\r\n\t<table class=\"table thead-light table-striped table-white box2\">\r\n\t\t<thead>\r\n\t\t\t<tr class=\"table-warning\">\r\n\t\t\t\t<th>\r\n\t\t\t\t\t");
#nullable restore
#line 25 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\t\t\t\t<th>\r\n\t\t\t\t\t");
#nullable restore
#line 28 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\t\t\t\t<th>\r\n\t\t\t\t\t");
#nullable restore
#line 31 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.TaskName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\t\t\t\t<th>\r\n\t\t\t\t\tOwnerFirstName\r\n\t\t\t\t</th>\r\n\t\t\t\t<th>\r\n\t\t\t\t\tOwnerLastName\r\n\t\t\t\t</th>\r\n\t\t\t\t\r\n\t\t\t\t<th>\r\n\t\t\t\t\t");
#nullable restore
#line 41 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.TaskOwnerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\t\t\t\t<th>\r\n\t\t\t\t\t");
#nullable restore
#line 44 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\r\n\t\t\t\t<th></th>\r\n\t\t\t\t<th></th>\r\n\t\t\t\t<th></th>\r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n");
#nullable restore
#line 53 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
             foreach (var item in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 57 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ProjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 60 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 63 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 66 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskOwnerFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 69 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskOwnerLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 73 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskOwnerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td class=\"lessertext\">\r\n\t\t\t\t\t\t");
#nullable restore
#line 76 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\r\n\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 81 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-primary", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 84 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-info", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 87 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-danger", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 90 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Task\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n</div>\r\n<br>\r\n<br>\r\n<br>\r\n<br>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Licenta_Front_End.Models.Task>> Html { get; private set; }
    }
}
#pragma warning restore 1591
