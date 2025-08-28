using Microsoft.OpenApi.Models;
using MyServiceRequestsAPI3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IServiceRequestsService, ServiceRequestsService>();

var app = builder.Build();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//if (!app.Environment.IsProduction())  // Dev/Test/Staging
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
