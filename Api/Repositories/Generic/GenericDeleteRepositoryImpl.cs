using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;


namespace Api.Repositories.Generic
{
    public class GenericDeleteRepositoryImpl<T> : IGenericDeleteRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericDeleteRepositoryImpl(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> DeleteAsync(T request)
        {
            _context.Set<T>().Remove(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}