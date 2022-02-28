using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
    }
}
