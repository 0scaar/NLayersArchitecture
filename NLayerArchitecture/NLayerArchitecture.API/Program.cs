using NLayerArchitecture.BLL.Reports;
using NLayerArchitecture.BLL.Repository;
using NLayerArchitecture.BLL.People;
using NLayerArchitecture.DAL;
using NLayerArchitecture.DTO;
using Microsoft.AspNetCore;
using NLayerArchitecture.API;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Run();
    }

    public static IWebHost CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>().Build();
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();


//var app = builder.Build();

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
