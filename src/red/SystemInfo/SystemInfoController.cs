using Microsoft.AspNetCore.Mvc;

namespace red.SystemInfo
{
    public class SystemInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Data()
        {
            return Ok(new object());
        }
    }
}