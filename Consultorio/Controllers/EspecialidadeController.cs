using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        IEspecialidadeRepository _especialidadeRepository;
        IMapper _mapper;
        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IMapper mapper)
        {
            _especialidadeRepository = especialidadeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _especialidadeRepository.GetEspecialidadesAsync();

            return especialidades.Any() ? Ok(especialidades) : BadRequest("Nenhuma especialidade cadastrada");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Especialidade inválida");

            var especialidade = await _especialidadeRepository.GetEspecialidadeByIdAsync(id);

            var especialidadeRetorno = _mapper.Map<EspecialidadeDetalhesDTO>(especialidade);

            return especialidadeRetorno != null ? Ok(especialidadeRetorno) : NotFound("Especialidade não localizada em banco");
        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeAdicionarDTO especialidade)
        {
            if (especialidade == null) return BadRequest("Especialidade inválida");

            var especialidadeAdicionar = new Especialidade
            {
                Nome = especialidade.Nome,
                Ativa = especialidade.Ativa
            };

            _especialidadeRepository.Add(especialidadeAdicionar);

            return await _especialidadeRepository.SaveChangesAsync() ?
                Ok(especialidadeAdicionar) :
                BadRequest("Não foi possível adicionar a especialidade");

        }

        [HttpPut("atualizar-status/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] bool status)
        {
            if (id <= 0) return BadRequest("Especialidade inválida");

            var especialidade = await _especialidadeRepository.GetEspecialidadeByIdAsync(id);
            if (especialidade == null) return NotFound("Especialidade não encontrada");

            var ativa = especialidade.Ativa ? "ativa" : "Inativa";
            if (especialidade.Ativa == status) return Ok($"Especialidade {especialidade.Nome} já está {ativa}");

            especialidade.Ativa = status;
            _especialidadeRepository.Update(especialidade);

            return await _especialidadeRepository.SaveChangesAsync() ? 
                Ok("Status atualizado") : 
                BadRequest("Não foi possível atualizar a especialidade");
        }

    }
}
