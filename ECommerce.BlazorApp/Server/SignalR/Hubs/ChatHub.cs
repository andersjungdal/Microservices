using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BlazorApp.Server.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        #region Join
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("NewUserEntered", "Hi, Welcome to group chat");
        }
        //public async Task JoinGroup2(string groupId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        //    await Clients.Caller.SendAsync("NewUserEntered2", "Hi, Welcome to group chat");
        //}
        //public async Task JoinGroup3(string groupId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        //    await Clients.Caller.SendAsync("NewUserEntered3", "Hi, Welcome to group chat");
        //}
        #endregion

        #region SendToGroup
        public async Task SendGroup(string message, string groupId)
        {
            await Clients.Group(groupId).SendAsync("SendMessageToGroup", message);
        }
        //public async Task SendGroup2(string message, string groupId)
        //{
        //    await Clients.Group(groupId).SendAsync("SendMessageToGroup2", message);
        //}
        //public async Task SendGroup3(string message, string groupId)
        //{
        //    await Clients.Group(groupId).SendAsync("SendMessageToGroup3", message);
        //}
        #endregion

        #region Leave
        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("UserLeaved", "Goodbye user");
        }
        //public async Task LeaveGroup2(string groupId)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        //    await Clients.Caller.SendAsync("UserLeaved2", "Goodbye user");
        //}
        //public async Task LeaveGroup3(string groupId)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        //    await Clients.Caller.SendAsync("UserLeaved3", "Goodbye user");
        //}
        #endregion

        //public async Task SendMessageToAll(string message)
        //{
        //    await Clients.All.SendAsync("SendMessageToGroup", message);
        //}

    }
}
