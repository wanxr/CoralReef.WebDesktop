using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Vue3_Vite.Services;

namespace Vue3_Vite.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenManagement _tokenManagement;

        public JwtMiddleware(RequestDelegate next, IOptions<TokenManagement> tokenManagement)
        {
            _next = next;
            _tokenManagement = tokenManagement.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IAuthenticate authenticate)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (authenticate.ValidateToken(token))
            {
                
            }else
            {
                
            }
            await _next(context);
        }
    }
}