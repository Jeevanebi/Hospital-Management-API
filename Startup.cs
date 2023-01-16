
using Microsoft.AspNetCore.Http.Authentication.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(HospitalManagementAPI.App_Start.Startup))]

namespace HospitalManagementAPI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = ConfigurationManager.AppSettings;
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        SaveSigninToken = true,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["JWTKey"],       // JWTIssuer - config value 
                        ValidAudience = config["JwtIssuer"],     // JWTIssuer - config value 
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["JWTKey"])) // JWTKey - config value 
                    }
                });
        }
    }
}
