using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        public IPacienteRepository _pacienteRepository { get; set; }
        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public IActionResult GetPacientes()
        {
            var pacientes = _pacienteRepository.GetPacientes();

            return pacientes.Any()
                            ? Ok(pacientes) 
                            : BadRequest("Não foram encontrados pacientes");

        }



    }
}
