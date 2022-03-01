using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        IProfissionalRepository _profissionalRepository;
        public ProfissionalController(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
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

            var profissional = https://www.youtube.com/watch?v=NMplO55WD4k&list=PLxd1RHU8YgYkHCbZqtqWuaYHASNERx-Tn&index=20 -> retomar 21:10s

            return 
        }
    }
}
