using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;

namespace Api.Repositories.Generic
{
    public class GenericPutRepositoryImpl<T> : IGenericPutRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericPutRepositoryImpl(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> PutAsync(T request)
        {
            _context.Set<T>().Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}