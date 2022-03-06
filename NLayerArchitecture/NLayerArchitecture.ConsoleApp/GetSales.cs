using NLayerArchitecture.BLL.Sales.Reports;
using System.Text.Json;

namespace NLayerArchitecture.ConsoleApp
{
    public class GetSales
    {
        private readonly ISales sales;

        public GetSales(ISales sales)
        {
            this.sales = sales;
        }

        public string GetSalesByName(string name)
        {
            var result = sales.GetSalesByName(name);

            return JsonSerializer.Serialize(result);
        }

    }
}
