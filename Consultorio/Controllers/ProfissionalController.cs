using AutoMapper;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        IProfissionalRepository _profissionalRepository;
        IMapper _mapper;
        public ProfissionalController(IProfissionalRepository profissionalRepository, IMapper mapper)
        {
            _profissionalRepository = profissionalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profissionais = await _profissionalRepository.GetProfissionaisAsync();

            return profissionais.Any() ? Ok(profissionais) : BadRequest("Não foram encontrados profissionais");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissional = await _profissionalRepository.GetProfissionalByIdAsync(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDTO>(profissional);

            return profissionalRetorno  != null ? 
                Ok(profissionalRetorno) : 
                NotFound("Profissional não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalAdicionarDTO profissional)
        {
            if(profissional == null) return BadRequest("Profissional informado é inválido");

            var profissionalAdicionar = _mapper.Map<Profissional>(profissional);

            _profissionalRepository.Add(profissionalAdicionar);

            return await _profissionalRepository.SaveChangesAsync() ? 
                Ok(profissionalAdicionar) : 
                BadRequest("Não foi possível adicionar o profissional");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, ProfissionalEditarDTO profissional)
        {
            if (id <= 0) return BadRequest("Profissional Inválido");

            var profissionalEmBanco = await _profissionalRepository.GetProfissionalByIdAsync(id);

            if (profissionalEmBanco == null) return BadRequest("Profissional não encontrado em banco");

            var profissionalEditar = _mapper.Map(profissional, profissionalEmBanco);

            _profissionalRepository.Update(profissionalEditar);

            return await _profissionalRepository.SaveChangesAsync() ? Ok(profissionalEditar) : BadRequest("Não foi possível editar o profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Profissional Inválido");

            var profissionalEmBanco = await _profissionalRepository.GetProfissionalByIdAsync(id);

            if(profissionalEmBanco == null) return NotFound("Profissional não localizado em banco");

            _profissionalRepository.Delete(profissionalEmBanco);

            return await _profissionalRepository.SaveChangesAsync() ? 
                Ok("Profissional deletado com suceesso") : 
                BadRequest("Não foi possível deletar o paciente.");
        }

    }
}
