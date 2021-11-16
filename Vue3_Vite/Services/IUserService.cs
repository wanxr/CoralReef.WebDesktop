using Vue3_Vite.Model;

namespace Vue3_Vite.Services
{
    public interface IUserService
    {
        public bool IsValid(UserInfo userInfo);
    }
}