using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Vue3_Vite.Authorization;
using Vue3_Vite.Entities;

namespace Vue3_Vite.Services
{
    public class JwtAuthentication : IAuthentication
    {
        private readonly TokenInfo _tokenManagement;
        private readonly IUserService _userService;

        public JwtAuthentication(IUserService userService, IOptions<TokenInfo> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
            this._userService = userService;
        }

        public string GenerateToken(UserInfo userInfo)
        {
            if (_userService.IsValid(userInfo))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _tokenManagement.Issuer,
                    Audience = _tokenManagement.Audience,
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("userId", userInfo.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(_tokenManagement.AccessExpiration),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else
            {
                return null;
            }
        }

        public bool ValidateToken(HttpContext context, string token)
        {
            if (token != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_tokenManagement.Secret);
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenManagement.Issuer,
                    ValidAudience = _tokenManagement.Audience,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "userId").Value;

                // attach user to context on successful jwt validation
                //context.Items["User"] = userService.GetById(userId);

                context.User = claimsPrincipal;

                return true;
            }
            return false;
        }
    }
}