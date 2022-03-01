using Consultorio.Context;
using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        ConsultorioContext _consultorioContext;
        public EspecialidadeRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<Especialidade> GetEspecialidadeByIdAsync(int id)
        {
            return await _consultorioContext.Especialidades.Where(e => e.Id == id).Include(e => e.Consultas).Include(e => e.Profissionais).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetEspecialidadesAsync()
        {
            return await _consultorioContext.Especialidades.Select(e => new EspecialidadeDTO
            {
                Nome = e.Nome,
                Ativa = e.Ativa
            }).ToListAsync();
        }
    }
}
