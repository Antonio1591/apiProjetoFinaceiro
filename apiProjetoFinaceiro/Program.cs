using api.Data;
using Microsoft.EntityFrameworkCore;
using apiProjetoFinaceiro.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using apiProjetoFinaceiro.Data.AutentificacaoIdentity;

var builder = WebApplication.CreateBuilder(args);
string stringDeConexao = builder.Configuration.GetConnectionString("conexaoMySQL");
builder.Services.AddDbContext<DataContext>(opt =>
opt.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao))
.UseSnakeCaseNamingConvention()
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIContagem", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                       Enter 'Bearer' [space] and then your in the text input below.
                       Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthenticationTokem(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("JwtOptions");

builder.Services.AddDbContext<IdentityDataContext>(opt =>
opt.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao))
.UseSnakeCaseNamingConvention());

builder.Services.AddDefaultIdentity<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<IdentityDataContext>()
        
        .AddDefaultTokenProviders();
builder.Services.AddScoped<IMovimentacaoFinanceiraServices,MovimentacaoFinaceiraServices>();
builder.Services.AddScoped<ITipoMovimentacaoServices, TipoMovimentacaoServices>();
builder.Services.AddScoped<IIdentityUsuarioServices, IdentityUsuarioServices>();
builder.Services.AddScoped<IAspNetUser, AspNetUser>();
builder.Services.AddScoped<HttpContextAccessor>();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.Services.AddServicesColletion();
app.MapControllers();
app.Run();
