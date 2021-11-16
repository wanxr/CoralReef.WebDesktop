using Vue3_Vite.Entities;

namespace Vue3_Vite.Services
{
    public interface IAuthenticate
    {
        public string GenerateToken(UserInfo userInfo);

        public bool ValidateToken(string token);
    }
}