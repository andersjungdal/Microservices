#pragma checksum "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e0da87dba68a114193e2c6f9b4846f8aaaa47d2"
// <auto-generated/>
#pragma warning disable 1591
namespace ECommerce.Blazor.Client.Pages.Chat
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using ECommerce.Blazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\_Imports.razor"
using ECommerce.Blazor.Client.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chat")]
    public partial class Chat : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Chat</h3>\r\n");
            __builder.OpenElement(1, "select");
            __builder.AddAttribute(2, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 5 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
               groupName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => groupName = __value, groupName));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenElement(5, "option");
            __builder.AddAttribute(6, "value", true);
            __builder.AddContent(7, "Select a room");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "option");
            __builder.AddAttribute(10, "value", "testroom1");
            __builder.AddContent(11, "rum1");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.OpenElement(13, "option");
            __builder.AddAttribute(14, "value", "testroom2");
            __builder.AddContent(15, "rum2");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n    ");
            __builder.OpenElement(17, "option");
            __builder.AddAttribute(18, "value", "testroom3");
            __builder.AddContent(19, "rum3");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.OpenElement(21, "option");
            __builder.AddAttribute(22, "value", "testroomAll");
            __builder.AddContent(23, "common room");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "form-group");
            __builder.AddMarkupContent(28, "\r\n    ");
            __builder.OpenElement(29, "label");
            __builder.AddMarkupContent(30, "\r\n        User:\r\n        ");
            __builder.OpenElement(31, "input");
            __builder.AddAttribute(32, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                      userName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => userName = __value, userName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n\r\n");
#nullable restore
#line 19 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
 switch (groupName)
{
    case "testroom1":
        if (userName == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(37, "            ");
            __builder.AddMarkupContent(38, "<p>You have to specify a name</p>\r\n");
#nullable restore
#line 25 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(39, "            ");
            __builder.OpenElement(40, "a");
            __builder.AddAttribute(41, "href", "/chatroom1/" + (
#nullable restore
#line 28 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                 userName.ToString()

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 28 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                      groupName.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(42, "Go to ");
            __builder.AddContent(43, 
#nullable restore
#line 28 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                                                   groupName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n");
#nullable restore
#line 32 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                         
        }
        break;
    case "testroom2":
        if (userName == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(45, "            ");
            __builder.AddMarkupContent(46, "<p>You have to specify a name</p>\r\n");
#nullable restore
#line 39 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(47, "            ");
            __builder.OpenElement(48, "a");
            __builder.AddAttribute(49, "href", "/chatroom2/" + (
#nullable restore
#line 42 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                 userName.ToString()

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 42 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                      groupName.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(50, "Go to ");
            __builder.AddContent(51, 
#nullable restore
#line 42 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                                                   groupName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n");
#nullable restore
#line 46 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                         
        }
        break;
    case "testroom3":
        if (userName == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(53, "            ");
            __builder.AddMarkupContent(54, "<p>You have to specify a name</p>\r\n");
#nullable restore
#line 53 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(55, "            ");
            __builder.OpenElement(56, "a");
            __builder.AddAttribute(57, "href", "/chatroom3/" + (
#nullable restore
#line 56 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                 userName.ToString()

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 56 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                      groupName.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(58, "Go to ");
            __builder.AddContent(59, 
#nullable restore
#line 56 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                                                   groupName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n");
#nullable restore
#line 60 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                         
        }
        break;
    case "testroomAll":
        if (userName == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(61, "            ");
            __builder.AddMarkupContent(62, "<p>You have to specify a name</p>\r\n");
#nullable restore
#line 67 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(63, "            ");
            __builder.OpenElement(64, "a");
            __builder.AddAttribute(65, "href", "/commonchatroom/" + (
#nullable restore
#line 70 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                      userName.ToString()

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 70 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                           groupName.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(66, "Go to ");
            __builder.AddContent(67, 
#nullable restore
#line 70 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                                                                                        groupName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n");
#nullable restore
#line 74 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
                         
        }
        break;
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 82 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\Chat.razor"
       


    public string userName { get; set; }

    private string groupName;



    //IsConnected => chatHubConnection.State == HubConnectionState.Connected;


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
