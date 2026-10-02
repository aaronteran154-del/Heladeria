using Microsoft.EntityFrameworkCore;
using Heladeria; // <-- Espacio de nombres de tu librería de clases

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar el DbContext utilizando PostgreSQL (Npgsql) y la cadena de conexión
builder.Services.AddDbContext<HeladeriaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CadenaConexion")));

// Agregar servicios para los controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
