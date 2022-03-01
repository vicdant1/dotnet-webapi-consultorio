using Consultorio.Context;
using Consultorio.Models.DTOs;
using Consultorio.Repository.Interfaces;

namespace Consultorio.Repository
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        ConsultorioContext _consultorioContext;
        public ProfissionalRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public Task<IEnumerable<ProfissionalDTO>> GetProfissionaisAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProfissionalDTO> GetProfissionalByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
