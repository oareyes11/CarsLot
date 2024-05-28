using Core.Implementations.Specification;
using Core.Repository.Interfaces;
using DB.context;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Generic
{
    public class GenericGetByIdRepositoryImpl<T> : IGenericGetByIdRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericGetByIdRepositoryImpl(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id, ISpecification<T>? specification = null)
        {
            if (specification is null)
            {
                return await _context.Set<T>().FindAsync(id) ?? null!;

            }
            return await ApplySpecification(specification).FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }
 
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}