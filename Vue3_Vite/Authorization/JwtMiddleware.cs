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
        private readonly IAuthentication _authenticate;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthentication authenticate)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!authenticate.ValidateToken(context, token) && !context.User.Identity.IsAuthenticated)
            {
                if (!context.Request.Path.Value.Equals("/") &&
                    !context.Request.Path.Value.StartsWith("/src/") &&
                    !context.Request.Path.Value.StartsWith("/@") &&
                    !context.Request.Path.Value.StartsWith("/node_modules") &&
                    !context.Request.Path.Value.StartsWith("/Api/Account") &&
                    !context.Request.Path.Value.StartsWith("/Api/Authentication")
                    )
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        Msg = "¼øÈ¨Ê§°Ü£¬ÇëÏÈµÇÂ¼£¡"
                    });
                    return;
                }
            }
            await _next(context);
        }
    }
}