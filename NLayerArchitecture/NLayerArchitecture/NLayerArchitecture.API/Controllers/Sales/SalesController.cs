using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.BLL.GetSalesByName;
using NLayerArchitecture.DTO;

namespace NLayerArchitecture.API.Controllers.Sales
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

        [HttpPost]
        [ProducesResponseType(typeof(List<Sale>), 200)]
        [Route("GetSalesByName")]
        public IActionResult Get([FromBody] SalesRequest input)
        {
            return Ok(sales.GetSalesByName(input.Name));
        }
    }
}
