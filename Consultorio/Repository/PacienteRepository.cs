using Consultorio.Context;
using Consultorio.Models.DTOs;
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
        public async Task<IEnumerable<PacienteDTO>> GetPacientesAsync()
        {
            return await _consultorioContext.Pacientes
                .Select(p => new PacienteDTO { Id = p.Id, Nome = p.Nome }).ToListAsync();
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _consultorioContext.Pacientes.Where(p => p.Id == id)
                .Include(p => p.Consultas)
                .ThenInclude(e => e.Especialidade)
                .ThenInclude(p => p.Profissionais)
                .FirstOrDefaultAsync();
        }

    }
}
