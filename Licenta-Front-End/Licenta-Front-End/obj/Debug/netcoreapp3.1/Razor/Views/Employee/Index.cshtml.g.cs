#pragma checksum "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9c327b5485d359d0866a8fe75914638cea0b0f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9c327b5485d359d0866a8fe75914638cea0b0f1", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b44f24061997867f5fddafee9a547c881632ec3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Licenta_Front_End.Models.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning fire"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
  
	ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 8 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
 using (Html.BeginForm("Index", "Employee", FormMethod.Get))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<p>\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9c327b5485d359d0866a8fe75914638cea0b0f14236", async() => {
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
            WriteLiteral("\r\n\t\t<input class=\"btn btn-warning fire\" type=\"submit\" value=\"Search\" placeholder=\"Search...\" />\r\n\t</p>\r\n\t<br>\r\n");
#nullable restore
#line 15 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
Write(Html.TextBox("searching", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<br>\r\n");
#nullable restore
#line 17 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n\r\n\r\n\r\n\t<div class=\"table-responsive box\">\r\n\t\t<table class=\"table thead-light table-striped table-white box2\">\r\n\r\n\t\t\t<thead class=\"table-warning\">\r\n\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 30 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 33 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 36 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 39 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.DepartamentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 42 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.JobTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 46 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th>\r\n\t\t\t\t\t\t");
#nullable restore
#line 49 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</th>\r\n\t\t\t\t\t<th></th>\r\n\t\t\t\t\t<th></th>\r\n\t\t\t\t\t<th></th>\r\n\t\t\t\t</tr>\r\n\t\t\t</thead>\r\n\t\t\t<tbody>\r\n");
#nullable restore
#line 57 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                 foreach (var item in Model)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 61 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 64 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 67 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 70 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DepartamentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 73 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.JobTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 77 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 80 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 83 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-primary", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 86 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.ActionLink("Details", "Details", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-info", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 89 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { Id = item.Id }, htmlAttributes: new { @class = "btn btn-danger", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 92 "E:\Licenta\Licenta-Front-End\Licenta-Front-End\Views\Employee\Index.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\r\n\t\t</table>\r\n\t</div>\r\n\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Licenta_Front_End.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
