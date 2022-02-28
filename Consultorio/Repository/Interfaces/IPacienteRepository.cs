using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDTO>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
    }
}
