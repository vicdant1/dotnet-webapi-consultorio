using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        public ProfissionalController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "OK";
        }

    }
}
