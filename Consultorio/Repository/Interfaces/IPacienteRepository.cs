using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        public IEnumerable<Paciente> GetPacientes();
        public Paciente GetPacienteById(int id);
    }
}
