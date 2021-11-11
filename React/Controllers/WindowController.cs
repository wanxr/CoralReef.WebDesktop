using Chromely.Core.Host;
using Chromely.NativeHost;
using Microsoft.AspNetCore.Mvc;

namespace CoralReef.WebEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WindowController:ControllerBase
    {
        [HttpPost("max")]
        public void MaxWindow()
        {
            NativeHostBase.NativeInstance.SetWindowState(WindowState.Maximize);
        }
    }
}
