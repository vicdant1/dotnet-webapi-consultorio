using Consultorio.Models.Entities;
using Consultorio.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        IEmailService _emailService;
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController(IEmailService emailService)
        {
            agendamentos.Add(new Agendamento { Id = 1, Nome = "João V", DataAgendamento = DateTime.Now });
            agendamentos.Add(new Agendamento { Id = 2, Nome = "João D", DataAgendamento = DateTime.Now });
            agendamentos.Add(new Agendamento { Id = 3, Nome = "João N", DataAgendamento = DateTime.Now });
            agendamentos.Add(new Agendamento { Id = 4, Nome = "João Z", DataAgendamento = DateTime.Now });
            _emailService = emailService;
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

        [HttpPost]
        public IActionResult Post()
        {
            var pacienteAgendado = true;

            if (pacienteAgendado)
            {
                _emailService.EnviarEmail("email@paciente.com");
            }

            return Ok();
        }

    }
}
