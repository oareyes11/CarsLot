
using Core.Implementations.Specification;
using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Generic
{
    public class GenericGetAllRepositoryImpl<T> : IGenericGetAllRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericGetAllRepositoryImpl(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T>? specification = null)
        {
            if (specification is null)
            {
                return await _context.Set<T>().ToListAsync();
            }
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}