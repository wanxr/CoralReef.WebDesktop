using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vue3_Vite.Model;
using Vue3_Vite.Services;

namespace Vue3_Vite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthenticationController(IAuthenticateService authService)
        {
            this._authService = authService;
        }

        [AllowAnonymous]
        [HttpPost, Route("GenerateToken")]
        public ActionResult GenerateToken([FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;
            if (_authService.IsAuthenticated(userInfo, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}