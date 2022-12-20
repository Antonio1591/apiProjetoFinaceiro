using api.Data;
using Microsoft.EntityFrameworkCore;
using apiProjetoFinaceiro.services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string stringDeConexao =builder.Configuration.GetConnectionString("conexaoMySQL");
builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao)));
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
