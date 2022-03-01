using Consultorio.Models.DTOs;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDTO>> GetEspecialidadesAsync();
        Task<Especialidade> GetEspecialidadeByIdAsync(int id);
    }
}
