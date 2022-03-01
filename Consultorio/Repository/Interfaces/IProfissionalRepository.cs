using Consultorio.Models.DTOs;

namespace Consultorio.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDTO>> GetProfissionaisAsync();
        Task<ProfissionalDTO> GetProfissionalByIdAsync();
    }
}
