using ApiFilmes.Core;
using ApiFilmes.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ListaDeFilmes>();

ListaDeFilmes.ListarFilmes();

builder.Services.AddScoped<RepositorioMock>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();
ApiKeyMiddleware.ApikeyAplicacao = builder.Configuration.GetValue<string>("ApiKeyAplicacao");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
