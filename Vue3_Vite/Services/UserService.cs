using Vue3_Vite.Entities;

namespace Vue3_Vite.Services
{
    public class UserService : IUserService
    {
        //模拟测试，默认都是人为验证有效
        public bool IsValid(UserInfo userInfo)
        {
            return true;
        }
    }
}