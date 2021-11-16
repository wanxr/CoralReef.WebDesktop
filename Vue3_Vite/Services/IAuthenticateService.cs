using Vue3_Vite.Model;

namespace Vue3_Vite.Services
{
    public interface IAuthenticateService
    {
        public bool IsAuthenticated(UserInfo userInfo, out string token);
    }
}