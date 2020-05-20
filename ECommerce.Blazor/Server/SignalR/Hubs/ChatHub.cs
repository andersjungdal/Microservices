using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Server.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public List<string> users = new List<string>();
        public async Task JoinGroup(string groupId/*, string userName*/)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("NewUserEntered", "Hi, Welcome to group chat");
            //users.Add(userName);
        }
        public async Task SendGroup(string message, string groupId)
        {
            await Clients.Group(groupId).SendAsync("SendMessageToGroup", message);
        }  
        public async Task LeaveGroup(string groupId/*, string userName*/)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("UserLeaved", "Goodbye user");
            //users.Remove(userName);
        }
        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("SendMessageToGroup", message);
        }

    }
}
