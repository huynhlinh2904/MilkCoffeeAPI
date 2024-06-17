using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MilkCoffeeAPI.Entities;
using MilkCoffeeAPI.Helpers;
using MilkCoffeeAPI.Services.CategoriesService;
using MilkCoffeeAPI.Services.ProductsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MILK COFFEE", Version = "v1" });
});

//connect db
builder.Services.AddDbContext<MilkCoffeeContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
//declare service
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();


// set up swagger
builder.Services.AddEndpointsApiExplorer();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MILK COFFEE API V1");
    });
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
