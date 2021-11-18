using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Vue3_Vite.Filters
{
    public class ApiAuthenticationAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}