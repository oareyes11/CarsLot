using DB.Entities;

namespace Core.Repository.Interfaces
{
    public interface IGenericGetAllRepo<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T>? specification = null);
    }
}