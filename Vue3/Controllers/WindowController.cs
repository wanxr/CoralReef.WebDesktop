using Chromely.Core.Host;
using Chromely.NativeHost;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoralReef.WebEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WindowController:ControllerBase
    {
        private readonly ILogger<WindowController> _logger;

        public WindowController(ILogger<WindowController> logger)
        {
            _logger = logger;
        }

        [HttpPost("max")]
        public void MaxWindow()
        {
            NativeHostBase.NativeInstance.SetWindowState(WindowState.Maximize);
        }
    }
}
