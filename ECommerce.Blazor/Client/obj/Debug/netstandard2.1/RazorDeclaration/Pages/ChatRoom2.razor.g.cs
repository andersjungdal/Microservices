#pragma checksum "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\ChatRoom2.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccbe36f1f205b12ab7e5ea8f7248565ad06ea7f9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ECommerce.Blazor.Client.Pages
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
#line 2 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\ChatRoom2.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chatroom2/{userName}/{groupName}")]
    public partial class ChatRoom2 : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\ander\Desktop\Microservices\ECommerce.Blazor\Client\Pages\ChatRoom2.razor"
       

    [Parameter]
    public string userName { get; set; }
    [Parameter]
    public string groupName { get; set; }

    private HubConnection chatHubConnection;

    private string userMessage;

    private List<string> messages = new List<string>();
    private bool userConnected;
    //private List<string> userList = new List<string>();

    protected override async Task OnInitializedAsync()
    {

        chatHubConnection = new HubConnectionBuilder()
        .WithUrl(NavigationManager.ToAbsoluteUri("/ChatHub"))
        .Build();

        chatHubConnection.On<string>("NewUserEntered", (x) =>
        {
            string encodedMessage = x;
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

    Task SendGroup() => chatHubConnection.SendAsync("SendGroup", $"{userName}:" + userMessage, groupName);

    Task LeaveGroup() => chatHubConnection.SendAsync("LeaveGroup", groupName);


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
