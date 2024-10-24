using System.Collections.Immutable;
using Gateway.Models;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

var serviceIpOptions = new ServiceIpOptions();
builder.Configuration.GetSection("ServiceIp").Bind(serviceIpOptions);
services.AddSingleton(serviceIpOptions);

builder.Services.AddTransient<IM2MAuthenticationService, M2MAuthenticationService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration.GetValue<string>("Auth0:Authority");
    options.Audience = builder.Configuration.GetValue<string>("Auth0:Audience");
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddHttpClient();
services.AddControllers().AddControllersAsServices();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();