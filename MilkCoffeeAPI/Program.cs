using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MilkCoffeeAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MilkCoffee", Version = "v1" });
});
builder.Services.AddDbContext<MilkCoffeeContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
var app = builder.Build();


// set up swagger
builder.Services.AddEndpointsApiExplorer();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MilkCoffee v1");
    options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
    options.DocumentTitle = "My Swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
