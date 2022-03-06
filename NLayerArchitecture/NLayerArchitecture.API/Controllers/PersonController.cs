using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.BLL.People;

namespace NLayerArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public readonly IPerson person;

        public PersonController(IPerson person)
        {
            this.person = person;
        }

        [HttpGet]
        public string Get()
        {
            return person.GetName();
        }
    }
}
