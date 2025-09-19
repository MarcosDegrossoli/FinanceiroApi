using Financeiro.Infrastructure.Data;
using Financeiro.Infrastructure.Interfaces;
using Financeiro.Infrastructure.Repositories;
using Financeiro.Services.Interfaces;
using Financeiro.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();

builder.Services.AddScoped<IContasService, ContasService>();
builder.Services.AddScoped<IContasRepository, ContasRepository>();

builder.Services.AddDbContext<FinanceiroDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
