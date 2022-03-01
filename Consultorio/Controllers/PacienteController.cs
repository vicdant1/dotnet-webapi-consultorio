using AutoMapper;
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
        private readonly IMapper _mapper;
        public PacienteController(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
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

            var pacienteRetorno = _mapper.Map<PacienteDetalhesDTO>(paciente);

            return pacienteRetorno == null ? NotFound("Paciente não encontrado") : Ok(pacienteRetorno);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteAdicionarDTO paciente)
        {
            if (paciente == null) return BadRequest("Dados Inválidos");

            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);

            _pacienteRepository.Add(pacienteAdicionar);

            return await _pacienteRepository.SaveChangesAsync() ? 
                Ok("Paciente adicionado com sucesso") : 
                BadRequest("Não foi possível adicionar o paciente");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteEditarDTO paciente)
        {
            if (id <= 0) return BadRequest("Usuário não informado");

            var pacienteEmBanco = await _pacienteRepository.GetPacienteByIdAsync(id);

            var pacienteAtualizar = _mapper.Map(paciente, pacienteEmBanco);

            _pacienteRepository.Update(pacienteAtualizar);

            return await _pacienteRepository.SaveChangesAsync() ? 
                Ok("Paciente editado com sucesso") : 
                BadRequest("Não foi possível editar o paciente");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Usuário Inválido");

            var pacienteEmBanco = await _pacienteRepository.GetPacienteByIdAsync(id);

            if (pacienteEmBanco == null) return NotFound("Paciente não encontrado");

            _pacienteRepository.Delete(pacienteEmBanco);

            return await _pacienteRepository.SaveChangesAsync() ?
                Ok("Paciente excluido com sucesso") :
                BadRequest("Não foi possível excluir o paciente");
        }



    }
}
