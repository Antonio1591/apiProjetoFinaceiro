using api.Data;
using apiProjetoFinaceiro.Model.Domain.UsuarioIdentityRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace apiProjetoFinaceiro.Data.AutentificacaoIdentity
{
    public static class AuthentificationSetup
    {
     
        public static void AddAuthenticationTokem(this IServiceCollection services, IConfiguration configurarion)
        {
            var jwtAppSettingOptions = configurarion.GetSection(nameof(JwtOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configurarion.GetSection("JwtOptions:SecurityKey").Value));

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
                options.signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                options.Expiration = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.Expiration)]);
            }
            );
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

            });
      
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configurarion.GetSection("JwtOptions:Issuer").Value,
                
                ValidateAudience = true,
                ValidAudience= configurarion.GetSection("JwtOptions:Audience").Value,
                
                ValidateIssuerSigningKey = true,
                IssuerSigningKey=securityKey,

                RequireExpirationTime=true,
                ValidateLifetime = true,

                ClockSkew= TimeSpan.Zero

            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        
        }

        public static async void AddServicesColletion(this IServiceProvider services)
        {

            await CreateRoles(services);
        }
        private static async Task CreateRoles(this IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
       
            string[] rolesNames = { "VIP", "GRATUITO" };
            IdentityResult result;
            foreach (var namesRole in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(namesRole));
                }
            }
        }


    }
}
