using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue3_Vite.Entities;
using Vue3_Vite.Services;

namespace Vue3_Vite.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticate _authService;
        private readonly IUserService _userService;

        public AuthenticationController(IAuthenticate authService, IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost, Route("GenerateToken")]
        public ActionResult GenerateToken([FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            string token = _authService.GenerateToken(userInfo);
            if (token != null)
            {
                return Ok(token);
            }
            return BadRequest("Invalid Request");
        }
    }
}