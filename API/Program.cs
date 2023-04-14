using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder
.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

//Middleware must be here before app.mapControllers
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
