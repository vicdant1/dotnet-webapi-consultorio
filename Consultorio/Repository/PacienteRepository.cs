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

        public Paciente GetPacienteById(int id)
        {
            throw new NotImplementedException();
            //var paciente = _consultorioContext.Pacientes.Where(p => p.Id == id).ToList();
        }

        public IEnumerable<Paciente> GetPacientes()
        {
            return _consultorioContext.Pacientes.Include(p => p.Consultas).ToList();
        }
    }
}
