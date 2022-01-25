using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = agendamentos.Where(a => a.Id == id).FirstOrDefault();

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }
    }
}
