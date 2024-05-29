using Core.Implementations.Specification;
using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Generic
{
    public class GenericGetByRepositoryImpl<T> : IGenericGetByRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericGetByRepositoryImpl(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByAsync(ISpecification<T>? specification = null)
        {
            if (specification is null)
            {
                return await _context.Set<T>().FirstOrDefaultAsync() ?? null!;
            }
            return await ApplySpecification(specification).FirstOrDefaultAsync() ?? null!;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}