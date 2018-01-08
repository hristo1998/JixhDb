namespace JixhDb.Services.Jwt
{
    using JixhDb.Models.JsonModels;
    using System.Collections.Generic;

    public interface IJwtSecurityTokenService
    {
        JwtJson CreateToken(string username, IList<string> role);
    }
}
