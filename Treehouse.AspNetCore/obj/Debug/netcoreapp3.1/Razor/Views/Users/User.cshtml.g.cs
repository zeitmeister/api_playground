#pragma checksum "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Users\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "201550f497c2bb0c6e35357b54207a82d028bb29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_User), @"mvc.1.0.view", @"/Views/Users/User.cshtml")]
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
#line 1 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\_ViewImports.cshtml"
using Treehouse.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\_ViewImports.cshtml"
using Treehouse.AspNetCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"201550f497c2bb0c6e35357b54207a82d028bb29", @"/Views/Users/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2c452e8b8f4a5746e040436b575c12bc8342594", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Treehouse.AspNetCore.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Users\User.cshtml"
  int index = 1; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n    <h1 class=\"display-4\">Hello ");
#nullable restore
#line 5 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Users\User.cshtml"
                           Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@".!</h1>
    <p class=""lead"">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>
    <hr class=""my-4"">
    <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>
    <a class=""btn btn-primary btn-lg"" href=""#"" role=""button"">Learn more</a>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Treehouse.AspNetCore.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591