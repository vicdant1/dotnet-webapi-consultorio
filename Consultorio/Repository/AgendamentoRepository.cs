using Consultorio.Context;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class AgendamentoRepository : BaseRepository, IAgendamentoRepository
    {
        ConsultorioContext _consultorioContext;
        public AgendamentoRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<Consulta> GetConsultaByIdAsync(int id)
        {
            return await _consultorioContext.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Profissional)
                .Include(c => c.Especialidade)
                .Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Consulta>> GetConsultasAsync()
        {
            return await _consultorioContext.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Profissional)
                .Include(c => c.Especialidade)
                .ToListAsync();
        }
    }
}
