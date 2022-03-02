using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IAgendamentoRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultasAsync();
        Task<Consulta> GetConsultaByIdAsync(int id);
    }
}
