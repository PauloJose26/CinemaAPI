using CinemaAPI.Data;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CinemaConnection");
builder.Services.AddDbContext<CinemaContext>(optionsBuilder => optionsBuilder
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .UseLazyLoadingProxies());

builder.Services.AddTransient<DAL<Filme>>();
builder.Services.AddTransient<DAL<Cinema>>();
builder.Services.AddTransient<DAL<Endereco>>();
builder.Services.AddTransient<DAL<Sessao>>();

builder.Services.AddControllers().AddNewtonsoftJson();
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