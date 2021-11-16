using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vue3_Vite.Model;

namespace Vue3_Vite.Services
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly TokenManagement _tokenManagement;

        public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenManagement)
        {
            _userService = userService;
            _tokenManagement = tokenManagement.Value;
        }

        public bool IsAuthenticated(UserInfo userInfo, out string token)
        {
            token = string.Empty;
            if (!_userService.IsValid(userInfo))
                return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userInfo.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return true;
        }
    }
}