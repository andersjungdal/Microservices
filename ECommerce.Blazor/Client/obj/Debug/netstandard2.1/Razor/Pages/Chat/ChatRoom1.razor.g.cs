#pragma checksum "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0861cd02635f8f51f634f935799573e32fc79692"
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
#nullable restore
#line 2 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chatroom1/{userName}/{groupName}")]
    public partial class ChatRoom1 : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 5 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
     groupName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(2, "\r\n\r\n");
            __builder.OpenElement(3, "h1");
            __builder.AddContent(4, 
#nullable restore
#line 7 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
     userName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
 if (!userConnected)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "    ");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
                      JoinGroup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Join");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 14 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "form-group");
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.OpenElement(15, "label");
            __builder.AddMarkupContent(16, "\r\n            Message:\r\n            ");
            __builder.OpenElement(17, "input");
            __builder.AddAttribute(18, "size", "50");
            __builder.AddAttribute(19, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 20 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
                          userMessage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => userMessage = __value, userMessage));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
            __builder.AddContent(24, "    ");
            __builder.OpenElement(25, "button");
            __builder.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
                      LeaveGroup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(27, "Leave");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n");
            __builder.AddContent(29, "    ");
            __builder.OpenElement(30, "button");
            __builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
                      SendGroup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(32, "Send");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n");
            __builder.AddContent(34, "    ");
            __builder.OpenElement(35, "ul");
            __builder.AddAttribute(36, "id", "messagesList");
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 29 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
         foreach (var message in messages)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(38, "            ");
            __builder.OpenElement(39, "li");
            __builder.AddContent(40, 
#nullable restore
#line 31 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
                 message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n");
#nullable restore
#line 32 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(42, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
#nullable restore
#line 34 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\Chat\ChatRoom1.razor"
       

    [Parameter]
    public string userName { get; set; }
    [Parameter]
    public string groupName { get; set; }


    private HubConnection chatHubConnection;

    private string userMessage;

    private List<string> messages = new List<string>();
    private bool userConnected;

    protected override async Task OnInitializedAsync()
    {

        chatHubConnection = new HubConnectionBuilder()
        .WithUrl(NavigationManager.ToAbsoluteUri("/ChatHub"))
        .Build();

        chatHubConnection.On<string>("NewUserEntered", (x) =>
        {
            string encodedMessage = x;
        //messages.Add(encodedMessage);
        userConnected = true;
            StateHasChanged();

        });
        chatHubConnection.On<string>("SendMessageToGroup", (x) =>
        {
            string encodedMessage = x;
            messages.Add(encodedMessage);
            StateHasChanged();
        });
        chatHubConnection.On<string>("UserLeaved", (x) =>
        {
            string encodedMessage = x;
            userConnected = false;
            StateHasChanged();
        });

        await chatHubConnection.StartAsync();

        //return base.OnInitializedAsync();
    }

    Task JoinGroup() => chatHubConnection.SendAsync("JoinGroup", groupName);

    Task SendGroup() => chatHubConnection.SendAsync("SendGroup", $"{userName}: " + userMessage, groupName);

    Task LeaveGroup() => chatHubConnection.SendAsync("LeaveGroup", groupName);



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
