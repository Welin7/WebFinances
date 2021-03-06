#pragma checksum "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b491bd481ad5f2aa77bb4b807cabd5e69c58723a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlaneAccount_Index), @"mvc.1.0.view", @"/Views/PlaneAccount/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PlaneAccount/Index.cshtml", typeof(AspNetCore.Views_PlaneAccount_Index))]
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
#line 1 "C:\Financeiro\WebFinancas\Views\_ViewImports.cshtml"
using WebFinancas;

#line default
#line hidden
#line 2 "C:\Financeiro\WebFinancas\Views\_ViewImports.cshtml"
using WebFinancas.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b491bd481ad5f2aa77bb4b807cabd5e69c58723a", @"/Views/PlaneAccount/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28ebe7e87695774d1376e480aa26bc4d4e0a9add", @"/Views/_ViewImports.cshtml")]
    public class Views_PlaneAccount_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 273, true);
            WriteLiteral(@"<h3>Registered Chart of Accounts</h3>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>#</th>
            <th>#</th>
            <th>ID</th>
            <th>DESCRIPTION</th>
            <th>TYPE</th>
        </tr>
    </thead>


");
            EndContext();
#line 15 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
      
        foreach (var item in (List<PlaneAccountModel>)ViewBag.ListPlaneAccount)
        {

#line default
#line hidden
            BeginContext(373, 112, true);
            WriteLiteral("            <tbody>\r\n                <tr>\r\n                    <th><button type=\"button\" class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("onclick", "onclick=\"", 485, "\"", 519, 3);
            WriteAttributeValue("", 494, "Edit(", 494, 5, true);
#line 20 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
WriteAttributeValue("", 499, item.Id.ToString(), 499, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 518, ")", 518, 1, true);
            EndWriteAttribute();
            BeginContext(520, 89, true);
            WriteLiteral(">Edit</button></th>\r\n                    <th><button type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 609, "\"", 646, 3);
            WriteAttributeValue("", 619, "Delete(", 619, 7, true);
#line 21 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
WriteAttributeValue("", 626, item.Id.ToString(), 626, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 645, ")", 645, 1, true);
            EndWriteAttribute();
            BeginContext(647, 47, true);
            WriteLiteral(">Delete</button></th>\r\n                    <th>");
            EndContext();
            BeginContext(695, 18, false);
#line 22 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
                   Write(item.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(713, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(745, 27, false);
#line 23 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
                   Write(item.Description.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(772, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(804, 20, false);
#line 24 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"
                   Write(item.Type.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(824, 52, true);
            WriteLiteral("</th>\r\n                </tr>\r\n            </tbody>\r\n");
            EndContext();
#line 27 "C:\Financeiro\WebFinancas\Views\PlaneAccount\Index.cshtml"

        }
    

#line default
#line hidden
            BeginContext(896, 509, true);
            WriteLiteral(@"
</table>

<button type=""button"" class=""btn btn-block btn-primary"" onclick=""CreatePlaneAccount()"">Create an Plane Account</button>

<script>
    function CreatePlaneAccount()
    {
        window.location.href = ""../PlaneAccount/CreatePlaneAccount"";
    }

    function Delete(Id)
    {
        window.location.href = ""../PlaneAccount/DeletePlaneAccount/"" + Id;
    }

    function Edit(Id) {
        window.location.href = ""../PlaneAccount/CreatePlaneAccountEdition/"" + Id;
    }
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
