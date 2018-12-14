#pragma checksum "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Shared\SurveyPrompt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5cc6b450beba6dda990bf681b347f07caff9ae0"
// <auto-generated/>
#pragma warning disable 1591
namespace Frontend.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using Frontend;
    using Frontend.Models.domain;
    using Frontend.Shared;
    using Newtonsoft.Json;
    using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Http;
    using System.Diagnostics;
    using System.Text;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Blazor.RenderTree;
    using Google.Apis.Auth.OAuth2;
    public class SurveyPrompt : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "alert alert-secondary mt-4");
            builder.AddAttribute(2, "role", "alert");
            builder.AddMarkupContent(3, "\n    <span class=\"oi oi-pencil mr-2\" aria-hidden=\"true\"></span> \n    ");
            builder.OpenElement(4, "strong");
            builder.AddContent(5, Title);
            builder.CloseElement();
            builder.AddContent(6, "\n\n    ");
            builder.AddMarkupContent(7, "<span class=\"text-nowrap\">\n        Please take our\n        <a target=\"_blank\" class=\"font-weight-bold\" href=\"https://go.microsoft.com/fwlink/?linkid=2041371\">brief survey</a>\n    </span>\n    and tell us what you think.\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 12 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Shared\SurveyPrompt.cshtml"
            
    [Parameter]
    string Title { get; set; } // Demonstrates how a parent component can supply parameters

#line default
#line hidden
    }
}
#pragma warning restore 1591
