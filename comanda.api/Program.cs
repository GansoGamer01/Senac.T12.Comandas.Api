using comanda.api;
using Microsoft.EntityFrameworkCore;
using SistemaDeComandas.BancoDeDados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// obtem o endereço do banco de dados
var conexao = builder.Configuration.GetConnectionString("conexao");
builder.Services.AddDbContext<ComandaContexto>(opt => 
{
    opt.UseMySql(conexao, ServerVersion.Parse("10.4.27-MariaDB"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigins"); // aplica a politica CORS \\

// AQUI criação do banco \\
using(var e = app.Services.CreateScope())
{
    var contexto = e.ServiceProvider.GetRequiredService <ComandaContexto>();
    contexto.Database.Migrate();

    // semear os dados iniciais \\
    InicializarDados.Semear(contexto);
}


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
