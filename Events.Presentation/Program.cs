using Events.Application;
using Events.Application.Common.Providers;
using Events.Domain.Entities;
using Events.Infrastructure;
using Events.Presentation;
using Events.Presentation.Middlewares;
using Events.Presentation.Options.Models;
using Events.Presentation.Options.Setups;
using Events.Presentation.Providers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
