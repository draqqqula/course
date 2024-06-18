using Infrastructure;
using Services;
using Core.Logic.Connections.RabbitMQ;
using Api.Listeners;
using Api.Listeners.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.TryAddRabbitMQ();
builder.Services.TryAddInfrastructure();
builder.Services.TryAddApplication();
builder.Services.AddSingleton<CreateProfileHandler>();
builder.Services.AddSingleton<GetProfileInfoHandler>();
builder.Services.AddHostedService<ProfileRabbitMQListener>();

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
