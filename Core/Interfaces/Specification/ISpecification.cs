using System.Linq.Expressions;

namespace Core.Repository.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criterial { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        void AddInclude(Expression<Func<T, object>> includeExpression);
        void AddCriterial(Expression<Func<T, bool>> criterialExpression);
    }
}