using Consultorio.Context;
using Consultorio.Repository.Interfaces;

namespace Consultorio.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ConsultorioContext _consultorioContext;
        public BaseRepository(ConsultorioContext consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _consultorioContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _consultorioContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _consultorioContext.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _consultorioContext.Update(entity);
        }
    }
}
