using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

//Middleware must be here before app.mapControllers
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
