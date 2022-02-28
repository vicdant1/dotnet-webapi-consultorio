using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
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
        public async Task<IActionResult> GetPacientes()
        {
            var pacientes = await _pacienteRepository.GetPacientesAsync();

            return pacientes.Any()
                            ? Ok(pacientes) 
                            : BadRequest("Não foram encontrados pacientes");
        }

        [HttpGet]
        [Route("{id}")]
        // seria o mesmo de ter feito [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);

            var pacienteRetorno = new PacienteDetalhesDTO
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Celular = paciente.Celular,
                //Cpf = paciente.Cpf,
                //Consultas = paciente.Consultas
                Consultas = new List<Consulta>()    
            };

            return pacienteRetorno == null ? NotFound("Paciente não encontrado") : Ok(pacienteRetorno);
        }

    }
}
