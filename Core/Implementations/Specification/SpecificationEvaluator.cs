using Core.Repository.Interfaces;
using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementations.Specification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            IQueryable<T>? query = inputQuery;
            if (specification.Criterial != null)
            {
                query = query.Where(specification.Criterial);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}