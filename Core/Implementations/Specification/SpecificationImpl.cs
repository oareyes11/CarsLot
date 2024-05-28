using System.Linq.Expressions;
using Core.Repository.Interfaces;

namespace Core.Implementations.Specification
{
    public class SpecificationImpl<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criterial { get; set; } = null!;
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddCriterial(Expression<Func<T, bool>> criterialExpression)
        {
            Criterial = criterialExpression;
        }
    }
}