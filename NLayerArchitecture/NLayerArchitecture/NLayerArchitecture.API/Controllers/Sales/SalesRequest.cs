using System.ComponentModel.DataAnnotations;

namespace NLayerArchitecture.API.Controllers.Sales
{
    public class SalesRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
