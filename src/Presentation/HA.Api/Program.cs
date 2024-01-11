using HA.Api.Startup;
using HA.Application;
using HA.Infrastructure.EF;
using HA.ResultAsp.MinimalApi.Mappers;
using HA.ResultAsp;
using HA.Api.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplication();
builder.Services.ConfigureEF(builder.Configuration);
builder.Services.AddResults();
builder.Services.AddScoped<IResultMapper, ResultsMinimalApiMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpoints();

app.Run();
