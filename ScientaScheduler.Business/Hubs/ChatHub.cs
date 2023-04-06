using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await SendMessage("", "User Connected");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceivedMessage",user, message);
        }
    }
}
