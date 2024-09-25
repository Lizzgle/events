using Events.Application;
using Events.Infrastructure;
using Events.Presentation;
using Events.Presentation.Middlewares;
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
