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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();