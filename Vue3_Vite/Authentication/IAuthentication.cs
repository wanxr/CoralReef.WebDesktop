using Microsoft.AspNetCore.Http;
using Vue3_Vite.Entities;

namespace Vue3_Vite.Authentication
{
    public interface IAuthentication
    {
        public string GenerateToken(UserInfo userInfo);

        public bool ValidateToken(HttpContext context, string token);
    }
}