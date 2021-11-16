using Chromely.Core.Host;
using Chromely.NativeHost;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoralReef.WebEnd.Controllers
{
    /// <summary>
    /// 窗体状态设置
    /// </summary>
    [ApiController]
    [Route("Api/[controller]")]
    public class WindowController : ControllerBase
    {
        private readonly ILogger<WindowController> _logger;

        public WindowController(ILogger<WindowController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 窗体最大化
        /// </summary>
        [HttpPost("max")]
        public void MaxWindow()
        {
            NativeHostBase.NativeInstance.SetWindowState(WindowState.Maximize);
        }
    }
}