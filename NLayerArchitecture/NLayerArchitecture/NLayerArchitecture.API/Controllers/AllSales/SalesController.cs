using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.BLL.GetAllSales;
using NLayerArchitecture.DTO;

namespace NLayerArchitecture.API.Controllers.AllSales
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IAllSales allSales;

        public SalesController(IAllSales allSales)
        {
            this.allSales = allSales;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Sale>), 200)]
        [Route("GetAllSales")]
        public IActionResult Get()
        {
            return Ok(allSales.GetAllSales());
        }
    }
}
