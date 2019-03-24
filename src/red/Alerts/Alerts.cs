using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace red.Alerts
{
    [Route("[controller]")]
    public class Alerts : Controller
    {
        private readonly IHubContext<AlertsHub> _hub;

        public Alerts(IHubContext<AlertsHub> hub)
        {
            _hub = hub;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Post()
        {
            string message;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                message = await reader.ReadToEndAsync();
            }

            await _hub.Clients.All.SendAsync("broadcastAlert", message);
            return Accepted();
        }
    }
}