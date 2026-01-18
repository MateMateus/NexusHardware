using Microsoft.EntityFrameworkCore;
using NexusHardware.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// --- Configuração do Banco de Dados ---
// 1. Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configura o Entity Framework para usar SQL Server
builder.Services.AddDbContext<NexusDbContext>(options =>
    options.UseSqlServer(connectionString));
// --------------------------------------

// Adiciona serviços para a API (Controllers e Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using Microsoft.EntityFrameworkCore;
using NexusHardware.Infrastructure.Context;
// 1. Adicione estes usings novos lá no topo:
using NexusHardware.Application.Interfaces;
using NexusHardware.Application.Services;
using NexusHardware.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- Configuração do Banco de Dados ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NexusDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- NOVO: Registro das Dependências (DI) ---
// Ensinamos a API a criar o Repositório e o Serviço
builder.Services.AddScoped<IComponenteRepository, ComponenteRepository>();
builder.Services.AddScoped<IComponenteService, ComponenteService>();
// ---------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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