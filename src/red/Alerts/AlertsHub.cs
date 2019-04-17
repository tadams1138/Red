using Microsoft.AspNetCore.SignalR;

namespace red.Alerts
{
    public class AlertsHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.SendAsync("broadcastAlert", message);
        }
    }
}