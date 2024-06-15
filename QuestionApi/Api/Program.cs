using Dal;
using Logic;
using Microsoft.Extensions.Configuration.Json;
using MyProfileConnectionLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.TryAddProfileConnection();
builder.Services.TryAddLogic();
builder.Configuration.AddJsonFile("datasettings.json");
builder.Services.TryAddDal(builder.Configuration.GetConnectionString("Db"));

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
