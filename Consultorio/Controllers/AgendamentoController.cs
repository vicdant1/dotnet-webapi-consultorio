using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        IAgendamentoRepository _agendamentoRepository;
        IMapper _mapper;
        public AgendamentoController(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agendamentos = await _agendamentoRepository.GetConsultasAsync();

            var consultasRetorno = _mapper.Map<IEnumerable<ConsultaDetalhesDTO>>(agendamentos);

            return consultasRetorno.Any() ? Ok(consultasRetorno) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido");

            var agendamento = await _agendamentoRepository.GetConsultaByIdAsync(id);

            var consultaRetorno = _mapper.Map<ConsultaDetalhesDTO>(agendamento);

            return consultaRetorno != null ? 
                Ok(consultaRetorno) : 
                NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgendamentoAdicionarDTO consulta)
        {
            if (consulta == null) return BadRequest("Consultta/Agendamento inválido");

            var consultaAdicionar = _mapper.Map<Consulta>(consulta);

            if (consultaAdicionar == null) return BadRequest("Consulta inválida");

            _agendamentoRepository.Add(consultaAdicionar);

            return await _agendamentoRepository.SaveChangesAsync() ? 
                Ok(consultaAdicionar) : 
                BadRequest("Não foi possível adicionar a consulta");

        }
    }
}
