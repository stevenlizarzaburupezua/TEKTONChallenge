using MediatR;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
 
using TekTon.ProductAPI.Application.Implementation;
using TekTon.ProductAPI.Application.Interface;
using TekTon.ProductAPI.Domain.Interface;
using TekTon.ProductAPI.Domain.Seedwork;
using TekTon.ProductAPI.DTO;
using TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter;
using TekTon.ProductAPI.Infrastructure.CrossCutting.AutoMapper;
using TekTon.ProductAPI.Repository.Context;
using TekTon.ProductAPI.Repository.Repositories;
using TekTon.ProductAPI.Repository.Seedwork.StoreProcedure;
using TekTon.ProductAPI.Repository.UnitofWork;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region SwaggerConf

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API GAP", Version = "v1", Description = "APIS utilizados en el sistema TEKTON" });
    c.IncludeXmlComments(Path.Combine(@"Infrastructure\Swagger\XML", $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"));
    c.IncludeXmlComments(Path.Combine(@"Infrastructure\Swagger\XML", "TekTon.ProductAPI.DTO.XML"));
    c.EnableAnnotations();
});

#endregion

#region Repository

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStoreProcedureManager, SqlServerProcedureManager>();

#endregion

#region Application

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

#endregion



#region Extensions

builder.Services.AddScoped<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>();

var serviceProvider = new ServiceCollection()
         .AddScoped<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>()
         .BuildServiceProvider();

var typeAdapterFactory = serviceProvider.GetRequiredService<ITypeAdapterFactory>();
TypeAdapterFactory.SetCurrent(typeAdapterFactory);

#endregion

builder.Services.AddDbContext<ProductAPIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
