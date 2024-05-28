using DB.Entities;

namespace Core.Repository.Interfaces
{
    public interface IGenericGetByIdRepo<T> where T : BaseEntity
    {
         Task<T> GetByIdAsync(int id, ISpecification<T>? specification = null);
    }
}