using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Operacao.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OperacaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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



/*criar um controle de usuários
qualquer um poderá criar mas apenas a manutenção pode ver a listagem e alterar o status
e apenas a gerencia poderá deletar*/
/*
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Operacao.Context;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para escutar nas portas 5000 (HTTP) e 5001 (HTTPS)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000); // HTTP
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS
    });
});

// Adicionar serviços ao contêiner.
builder.Services.AddDbContext<OperacaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseHttpsRedirection();

// Adicionar suporte para arquivos estáticos
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Roteamento para o HTML principal
app.MapFallbackToFile("manutencao.html");

app.Run();


/*
swagger
    "launchUrl": "swagger",
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
*/