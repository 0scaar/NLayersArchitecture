// See https://aka.ms/new-console-template for more information

using NLayerArchitecture.BLL.Sales.Reports;
using Autofac;
using NLayerArchitecture.BLL.Reports;
using NLayerArchitecture.BLL.Repository;
using System.Text.Json;
using NLayerArchitecture.DAL;
using NLayerArchitecture.DTO;

class Program
{
    static void Main(string[] args)
    {
        Configure();
    }

    static void Configure()
    {
        var container = RegisterContainers();
        Getresult(container);
    }

    private static IContainer RegisterContainers()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<Sales>().As<ISales>().InstancePerLifetimeScope();
        builder.RegisterType<TData<Sale>>().As<IData<Sale>>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder.Build();
    }

    public static string Getresult(IContainer container)
    {
        var sales = container.Resolve<ISales>();
        var result =  sales.GetSalesByName("Oscar");
        return JsonSerializer.Serialize(result);
    }   
}



