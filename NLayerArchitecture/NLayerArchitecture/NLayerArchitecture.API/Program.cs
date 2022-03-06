using AutoMapper;
using NLayerArchitecture.BLL.GetAllSales;
using NLayerArchitecture.BLL.GetSalesByName;
using NLayerArchitecture.BLL.People;
using NLayerArchitecture.BLL.Repository;
using NLayerArchitecture.DAL.Modules;
using NLayerArchitecture.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IPerson, Person>();
builder.Services.AddSingleton<ISales, Sales>();
builder.Services.AddSingleton<IAllSales, AllSales>();
builder.Services.AddSingleton<ICallProcedure<Sale>, NLayerArchitecture.DAL.Repositories.CallProcedure<Sale>>();

// Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(CommonMappingProfile));

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
