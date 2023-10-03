using FluentResults.Extensions.AspNetCore;
using HA.Api.ErrorHandlers;
using HA.Api.Startup;
using HA.Application;
using HA.Infrastructure.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen();

AspNetCoreResult.Setup(config => config.DefaultProfile = new ErrorBaseResultProblemDetailProfile());
builder.Services.ConfigureApplication();
builder.Services.ConfigureEF(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints();

app.Run();
