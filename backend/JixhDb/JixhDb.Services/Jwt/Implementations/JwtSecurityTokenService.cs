namespace JixhDb.Services.Jwt.Implementations
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using JixhDb.Services.Jwt.Helpers;
    using JixhDb.Models.JsonModels;

    public class JwtSecurityTokenService : IJwtSecurityTokenService, IService
    {
        public JwtJson CreateToken(string username, IList<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtJson(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}

