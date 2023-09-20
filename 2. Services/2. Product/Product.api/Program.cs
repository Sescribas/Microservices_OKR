using MediatR;
using OKR.Common.Repositories.Interfaces;
using OKR.Common.Repositories;
using OKR.Common.Services.Interfaces;
using OKR.Common.Services;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OKR.Common.Persistence.Database.ProductDbContext;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductDBContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductStockRepository, ProductStockRepository>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductStockService, ProductStockService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR(Assembly.Load("Product.Services.EventHandlers"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
