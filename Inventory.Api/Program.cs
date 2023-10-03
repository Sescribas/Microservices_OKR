using MediatR;
using MongoDB.Driver;
using OKR.Common.Configuration.Configurations.IdentityApi;
using OKR.Common.Configuration.Configurations.ProductApi;
using OKR.Common.Domain.Automapper;
using OKR.Common.Persistence.Database.SellDbContext;
using OKR.Common.Repositories;
using OKR.Common.Repositories.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "mongodb://localhost:27017"; 
var databaseName = "Inventory";

builder.Services.AddSingleton<IMongoClient>(provider => new MongoClient(connectionString));
builder.Services.AddSingleton(provider => provider.GetRequiredService<IMongoClient>().GetDatabase(databaseName));
builder.Services.AddTransient<ISellCollection, SellCollection>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductStockRepository, ProductStockRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

#region IOptions

builder.Services.Configure<IdentityApiConfigurationsOptions>(builder.Configuration.GetSection("IdentityApi"));
builder.Services.Configure<ProductApiConfigurationsOptions>(builder.Configuration.GetSection("ProductApi"));

#endregion

builder.Services.AddMediatR(Assembly.Load("Inventory.Services.EventHandler"));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(SellProfile)));
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
