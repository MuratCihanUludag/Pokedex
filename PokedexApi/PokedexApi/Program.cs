using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using PokedexApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokedex", Version = "v1" });
});
string connectionString = builder.Configuration.GetConnectionString("PokedexConnection");

builder.Services.AddDbContext<PokemonDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokedex v1");

});
app.UseAuthorization();

app.MapControllers();

app.Run();
