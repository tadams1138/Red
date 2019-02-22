using Microsoft.AspNetCore.SignalR;

namespace red.Chat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}