using Microsoft.AspNetCore.Http;
using Vue3_Vite.Entities;

namespace Vue3_Vite.Services
{
    public interface IAuthentication
    {
        public string GenerateToken(UserInfo userInfo);

        public bool ValidateToken(HttpContext context, string token);
    }
}