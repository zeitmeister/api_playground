#pragma checksum "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccbb0dd9ed5fba983fb5d5b38d3a7bd6cfcded74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Questions_Question), @"mvc.1.0.view", @"/Views/Questions/Question.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccbb0dd9ed5fba983fb5d5b38d3a7bd6cfcded74", @"/Views/Questions/Question.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2c452e8b8f4a5746e040436b575c12bc8342594", @"/Views/_ViewImports.cshtml")]
    public class Views_Questions_Question : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Treehouse.AspNetCore.Models.QuestionModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
  
    ViewData["Title"] = "Question";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Question</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 13 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </th>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 19 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.createdAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </th>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 24 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelItem => @Model.text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelItem => @Model.createdAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelItem => @Model.username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<h2>Answers</h2>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Rank\r\n            </th>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 56 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.answers.FirstOrDefault().answeredBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 60 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.answers.FirstOrDefault().votes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n\r\n                ");
#nullable restore
#line 64 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayNameFor(model => model.text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 69 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
          int index = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
         foreach (var answer in @Model.answers)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelItem => answer.answeredBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelitem => answer.votes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 83 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
           Write(Html.DisplayFor(modelItem => answer.text));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 86 "C:\Users\KM\source\repos\solar_system\Treehouse.AspNetCore\Views\Questions\Question.cshtml"
            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Treehouse.AspNetCore.Models.QuestionModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
