using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDTO>> GetProfissionaisAsync();
        Task<Profissional> GetProfissionalByIdAsync(int id);
        Task<ProfissionalEspecialidade> GetProfissionalEspecialidade(int idProfissional, int idEspecialidade);
    }
}
