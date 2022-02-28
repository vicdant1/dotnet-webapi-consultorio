using Consultorio.Context;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly ConsultorioContext _consultorioContext;
        public PacienteRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _consultorioContext.Pacientes.Where(p => p.Id == id).Include(p => p.Consultas).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await _consultorioContext.Pacientes.Include(p => p.Consultas).ToListAsync();
        }
    }
}
