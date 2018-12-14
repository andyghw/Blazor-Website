#pragma checksum "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6e3e648a581f1ca5fcf6013a5854207071dc6eb"
// <auto-generated/>
#pragma warning disable 1591
namespace Frontend.Pages
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
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/comments")]
    public class myComments : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
#line 6 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
 if (comments == null)
{

#line default
#line hidden
            builder.AddContent(0, "    ");
            builder.AddMarkupContent(1, "<p><em>Loading...</em></p>\n");
#line 9 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
}
else
{

#line default
#line hidden
            builder.AddContent(2, "    ");
            builder.OpenElement(3, "div");
            builder.AddAttribute(4, "class", "my-3 p-3 bg-white rounded shadow-sm comments");
            builder.AddContent(5, "\n        ");
            builder.AddMarkupContent(6, "<h6 class=\"border-bottom border-gray pb-2 mb-0\">My Comments</h6>\n");
#line 14 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
         foreach (var comment in comments)
        {

#line default
#line hidden
            builder.AddContent(7, "            ");
            builder.OpenElement(8, "div");
            builder.AddAttribute(9, "class", "media text-muted pt-3");
            builder.AddContent(10, "\n                ");
            builder.OpenElement(11, "div");
            builder.AddAttribute(12, "class", "media-body pb-3 mb-0 small lh-125 border-bottom border-gray");
            builder.AddMarkupContent(13, "\n                    <img src=\"http://www.icons101.com/icon_png/size_512/id_29125/tomato.png\" width=\"32\" height=\"32\" alt=\"\" class=\"mr-2 rounded\">\n                    ");
            builder.OpenElement(14, "a");
            builder.AddAttribute(15, "class", "d-block");
            builder.AddAttribute(16, "style", "font-size:30px;");
            builder.AddAttribute(17, "href", "/movie/" + (comment.movieName));
            builder.AddContent(18, comment.movieName);
            builder.CloseElement();
            builder.AddContent(19, "\n                    ");
            builder.OpenElement(20, "div");
            builder.AddAttribute(21, "class", "d-flex justify-content-between align-items-center w-100");
            builder.AddContent(22, "\n                        ");
            builder.OpenElement(23, "strong");
            builder.AddAttribute(24, "class", "text-gray-dark");
            builder.AddAttribute(25, "style", "font-size:30px; color:blue");
            builder.AddContent(26, "@");
            builder.AddContent(27, comment.username);
            builder.CloseElement();
            builder.AddContent(28, "\n                        ");
            builder.OpenElement(29, "button");
            builder.AddAttribute(30, "class", "btn btn-danger");
            builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Blazor.Components.BindMethods.GetEventHandlerValue<Microsoft.AspNetCore.Blazor.UIMouseEventArgs>( () =>DeleteComment(comment.commentID)));
            builder.AddContent(32, "Delete");
            builder.CloseElement();
            builder.AddContent(33, "\n                    ");
            builder.CloseElement();
            builder.AddMarkupContent(34, "\n                    <br>\n                    ");
            builder.OpenElement(35, "span");
            builder.AddAttribute(36, "class", "d-block");
            builder.AddAttribute(37, "style", "font-size:20px; color:black");
            builder.AddContent(38, comment.text);
            builder.CloseElement();
            builder.AddMarkupContent(39, "\n                    <br>\n                    ");
            builder.OpenElement(40, "span");
            builder.AddAttribute(41, "class", "d-block");
            builder.AddAttribute(42, "style", "font-size:25px");
            builder.AddContent(43, "Rating: ");
            builder.AddContent(44, comment.rating);
            builder.CloseElement();
            builder.AddMarkupContent(45, "\n                    <br>\n                    ");
            builder.OpenElement(46, "span");
            builder.AddAttribute(47, "class", "d-block");
            builder.AddContent(48, "Date: ");
            builder.AddContent(49, comment.createDate.ToString("d"));
            builder.CloseElement();
            builder.AddContent(50, "\n                ");
            builder.CloseElement();
            builder.AddContent(51, "\n            ");
            builder.CloseElement();
            builder.AddContent(52, "\n");
#line 32 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
        }

#line default
#line hidden
            builder.AddContent(53, "    ");
            builder.CloseElement();
            builder.AddContent(54, "\n");
#line 34 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 36 "D:\Study\GuoHanwen\Master\Info6250\FinalProject\Frontend\Pages\myComments.cshtml"
           
    private List<Comment> comments;

    protected override async Task OnInitAsync()
    {
        var username = await localStorage.GetItem<string>("username");
        var response = await Http.GetAsync("http://localhost:5000/api/Comments/GetCommentsByV/" + username);
        var str = await response.Content.ReadAsStringAsync();
        if (str != null)
        {
            comments = Json.Deserialize<List<Comment>>(str);
        }
    }

    public async Task DeleteComment(int id)
    {
        await Http.DeleteAsync("http://localhost:5000/api/Comments/DeleteComment/" + id);
        UriHelper.NavigateTo("/");
        UriHelper.NavigateTo("/comments");
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private Blazored.Storage.ILocalStorage localStorage { get; set; }
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private Microsoft.AspNetCore.Blazor.Services.IUriHelper UriHelper { get; set; }
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
