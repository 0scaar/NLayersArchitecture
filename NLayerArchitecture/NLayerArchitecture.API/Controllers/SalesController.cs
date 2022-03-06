
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.BLL.Reports;
using System.Text.Json;

namespace NLayerArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISales sales;

        public SalesController(ISales sales)
        {
            this.sales = sales;
        }

        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(sales.GetSalesByName("Oscar"));
        }

    }
}
