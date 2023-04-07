using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            await SendChatMessage(string.Empty, $"{username} connected...");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string username = Users.FirstOrDefault(u=> u.Key == Context.ConnectionId).Value;
            await SendChatMessage(string.Empty, $"{username} disconnected");
        }

        public async Task SendChatMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceivedChatMessage",user, message);
        }

    }
}
