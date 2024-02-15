using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Util
{
    public static class GenerateJsonToken
    {
        public static string GenerateTokenString(this Account account,string secretKey,DateTime now)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier ,account.UserName),
                new Claim(ClaimTypes.Role, account.Role.RoleName),
            };
            var token = new JwtSecurityToken(
               issuer: secretKey,
               audience: secretKey,
               claims,
               expires: now.AddMinutes(120),
               signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public static ClaimsPrincipal? GetPrincipalFromExpiredToken(this string? token, string secretKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.CanReadToken(token))
            {

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            else return null;


        }
    }
}
