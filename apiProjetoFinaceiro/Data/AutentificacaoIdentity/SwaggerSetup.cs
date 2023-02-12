﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Security.Cryptography.Xml;
using System.Security.Permissions;

namespace apiProjetoFinaceiro.Data.AutentificacaoIdentity
{
    public static class SwaggerSetup
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Way2Commerce.Api",
                    Version = "v1"
                });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Way2Commerce.Api",
                    Version = "v2"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                                  Enter 'Bearer' [space] and then your in the text input below.
                                  Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type= ReferenceType.SecurityScheme,
                            Id= "Bearer"
                        },
                        Scheme="oauth2",
                        Name= "Bearer",
                        In=ParameterLocation.Header
                    },
                    new List<string>()
                    }

                });
            });
        }

        public static void UseSwggerUi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                {
                    var apiVersionProvider = app.Services.GetService<IApiVersionDescriptionProvider>();
                    if (apiVersionProvider == null)
                        throw new ArgumentException("API versiong not registered");
                    foreach (var description  in apiVersionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                    }
                    options.RoutePrefix = string.Empty;
                    options.DocExpansion(DocExpansion.List);
                });
        }
    }
}
