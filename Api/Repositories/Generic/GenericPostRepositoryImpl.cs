using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;

namespace Api.Repositories.Generic
{
    public class GenericPostRepositoryImpl<T> : IGenericPostRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericPostRepositoryImpl(StoreContext context)
        {
            _context = context;
        }


        async Task<T> IGenericPostRepo<T>.PostAsync(T request)
        {
            await _context.Set<T>().AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}