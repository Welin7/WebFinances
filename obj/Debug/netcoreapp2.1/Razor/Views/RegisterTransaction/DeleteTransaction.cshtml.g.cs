#pragma checksum "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f5f72fe4515e42e01f380e570c479053fcc2879"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RegisterTransaction_DeleteTransaction), @"mvc.1.0.view", @"/Views/RegisterTransaction/DeleteTransaction.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RegisterTransaction/DeleteTransaction.cshtml", typeof(AspNetCore.Views_RegisterTransaction_DeleteTransaction))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f5f72fe4515e42e01f380e570c479053fcc2879", @"/Views/RegisterTransaction/DeleteTransaction.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28ebe7e87695774d1376e480aa26bc4d4e0a9add", @"/Views/_ViewImports.cshtml")]
    public class Views_RegisterTransaction_DeleteTransaction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 75, true);
            WriteLiteral("<h3>Do you want to delete the selected transaction?</h3>\r\n<br/>\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(79, 28, true);
            WriteLiteral("    <p><strong>ID:</strong> ");
            EndContext();
            BeginContext(108, 40, false);
#line 6 "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml"
                       Write(ViewBag.RecordsTransaction.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(148, 48, true);
            WriteLiteral("</p>\r\n    <p><strong>Date Transaction:</strong> ");
            EndContext();
            BeginContext(197, 53, false);
#line 7 "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml"
                                     Write(ViewBag.RecordsTransaction.DateTransaction.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(250, 43, true);
            WriteLiteral("</p>\r\n    <p><strong>Description:</strong> ");
            EndContext();
            BeginContext(294, 49, false);
#line 8 "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml"
                                Write(ViewBag.RecordsTransaction.Description.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(343, 37, true);
            WriteLiteral("</p>\r\n    <p><strong>Value:</strong> ");
            EndContext();
            BeginContext(381, 43, false);
#line 9 "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml"
                          Write(ViewBag.RecordsTransaction.Value.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(424, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(433, 115, true);
            WriteLiteral("\r\n<button type=\"button\" onclick=\"Cancel()\" class=\"btn btn-block btn-default\">Cancel</button>\r\n<button type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 548, "\"", 607, 3);
            WriteAttributeValue("", 558, "Delete(", 558, 7, true);
#line 13 "C:\Financeiro\WebFinancas\Views\RegisterTransaction\DeleteTransaction.cshtml"
WriteAttributeValue("", 565, ViewBag.RecordsTransaction.Id.ToString(), 565, 41, false);

#line default
#line hidden
            WriteAttributeValue("", 606, ")", 606, 1, true);
            EndWriteAttribute();
            BeginContext(608, 283, true);
            WriteLiteral(@" class=""btn btn-block btn-danger"">Delete</button>

<script>
    function Cancel() {
        window.location.href = ""../../RegisterTransaction/Index"";
    }

    function Delete(Id) {
        window.location.href = ""../../RegisterTransaction/Delete/"" + Id;
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
