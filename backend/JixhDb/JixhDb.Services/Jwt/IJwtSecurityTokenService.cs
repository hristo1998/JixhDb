namespace JixhDb.Services.Jwt
{
    using System.Collections.Generic;

    public interface IJwtSecurityTokenService
    {
        string CreateToken(string username, IList<string> role);
    }
}
