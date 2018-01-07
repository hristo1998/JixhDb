namespace JixhDb.Web.Infrastructure.Extensions
{
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using JixhDb.Services.Jwt.Helpers;

    public static class CustomJwtServiceExtention
    {
        public static AuthenticationBuilder AddCustomJwt(this AuthenticationBuilder builder)
        {
            builder.AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret)),

                    ValidateIssuer = false,
                    ValidIssuer = "The name of the issuer",

                    ValidateAudience = false,
                    ValidAudience = "The name of the audience",

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            return builder;
        }
    }
}
