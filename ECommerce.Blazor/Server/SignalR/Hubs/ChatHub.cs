using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Server.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("NewUserEntered", "velkommen til gruppe-chatten");
        }
        public async Task SendTilGruppe(string besked, string gruppeid)
        {
            await Clients.Group(gruppeid).SendAsync("SendBeskedTilGruppe", besked);
        }
        
    }
}
