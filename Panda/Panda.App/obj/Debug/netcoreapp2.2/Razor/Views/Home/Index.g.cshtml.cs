#pragma checksum "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8551d1893023dc28f92dfc9da17bf2ca62cd1c46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8551d1893023dc28f92dfc9da17bf2ca62cd1c46", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"101821730a265020d06d2b882665c4b4be43ceb2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\teodo\source\repos\Panda\Panda.App\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 340, true);
            WriteLiteral(@"
    <div class=""jumbotron mt-3 bg-panda"">
        <h1 class=""text-white"">Welcome to PANDA Delivery Services.</h1>
        <hr class=""bg-white hr-2"" />
        <h3 class=""text-white""><a href=""/login"">Login</a> if you have an account.</h3>
        <h3 class=""text-white""><a href=""/register"">Register</a> if you don't.</h3>
    </div>
");
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
