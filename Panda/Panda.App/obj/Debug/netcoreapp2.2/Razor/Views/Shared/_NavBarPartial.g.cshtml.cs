#pragma checksum "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74d74ce7272a9e16b2ad2a55c008a9925b38e9c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NavBarPartial), @"mvc.1.0.view", @"/Views/Shared/_NavBarPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_NavBarPartial.cshtml", typeof(AspNetCore.Views_Shared__NavBarPartial))]
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
#line 1 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\_ViewImports.cshtml"
using Panda.App;

#line default
#line hidden
#line 2 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\_ViewImports.cshtml"
using Panda.App.Models;

#line default
#line hidden
#line 1 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml"
using Panda.Domain;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d74ce7272a9e16b2ad2a55c008a9925b38e9c2", @"/Views/Shared/_NavBarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"101821730a265020d06d2b882665c4b4be43ceb2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NavBarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(151, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml"
 if (this.User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(198, 1073, true);
            WriteLiteral(@"    <nav class=""navbar navbar-expand-lg navbar-dark bg-panda"">
        <a class=""navbar-brand nav-link-white"" href=""/"">PANDA</a>
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarNav"" aria-controls=""navbarNav"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>
        <div class=""collapse navbar-collapse d-flex justify-content-between"" id=""navbarNav"">
            <ul class=""navbar-nav"">
            </ul>
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/"">Home</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/my-receipts"">Receipts</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/logout"">Logout</a>
                </li>");
            WriteLiteral("\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n");
            EndContext();
#line 29 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1283, 1105, true);
            WriteLiteral(@"    <nav class=""navbar navbar-expand-lg navbar-dark bg-panda"">
        <a class=""navbar-brand nav-link-white"" href=""/"">PANDA</a>
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarNav"" aria-controls=""navbarNav"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>
        <div class=""collapse navbar-collapse justify-content-between d-inline-flex"" id=""navbarNav"">
            <ul class=""navbar-nav""></ul>
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/Home/Index"">Home</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/Identity/Account/Login"">Login</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link nav-link-white active"" href=""/Identity/Account/Register"">Reg");
            WriteLiteral("ister</a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n");
            EndContext();
#line 52 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Shared\_NavBarPartial.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<PandaUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<PandaUser> SignInManager { get; private set; }
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