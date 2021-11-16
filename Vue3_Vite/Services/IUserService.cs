using Vue3_Vite.Entities;

namespace Vue3_Vite.Services
{
    public interface IUserService
    {
        public bool IsValid(UserInfo userInfo);
    }
}