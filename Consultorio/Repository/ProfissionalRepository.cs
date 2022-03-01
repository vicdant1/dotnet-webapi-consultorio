using Consultorio.Context;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        ConsultorioContext _consultorioContext;
        public ProfissionalRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<IEnumerable<ProfissionalDTO>> GetProfissionaisAsync()
        {
            return await _consultorioContext.Profissionais.Select(x => new ProfissionalDTO
            {
                Id = x.Id,
                Nome = x.Nome,
                Ativo = x.Ativo
            }).ToListAsync();
        }

        public async Task<Profissional> GetProfissionalByIdAsync(int id)
        {
            return await _consultorioContext.Profissionais
                .Include(p => p.Especialidades)
                .Include(p => p.Consultas)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
