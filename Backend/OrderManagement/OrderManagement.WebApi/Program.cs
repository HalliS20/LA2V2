using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Repository.Implementations;
using OrderManagement.Repository.Interfaces;
using OrderManagement.Services.Implementations;
using OrderManagement.Services.Interfaces;
using Orders.API.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration.GetValue<string>("Auth0:Authority");
    options.Audience = builder.Configuration.GetValue<string>("Auth0:Audience");
});

var connectionString = builder.Configuration.GetSection("ConnectionStrings")["ECommerceDatabase"];

builder.Services.AddDbContext<OrdersApiContext>(options =>
    options.UseNpgsql(
        connectionString,
        b => b.MigrationsAssembly("OrderManagement.WebApi")
    )
);


builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrdersApiContext>();
    dbContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
