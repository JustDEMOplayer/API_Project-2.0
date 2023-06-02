using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess.Wrapper;
using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<InternetShopContext>(options =>
                                options.UseSqlServer("Server= HarComp;Database= InternetShop;Integrated Security= True;"));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddScoped<IGoodCharachteristicService, GoodCharachteristicService>();
builder.Services.AddScoped<IGoodService, GoodService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "Version 2.0",
        Title = "Проект API",
        Description = "Вы можете редактировать банные из БД",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
