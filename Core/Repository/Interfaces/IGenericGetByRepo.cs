using DB.Entities;
namespace Core.Repository.Interfaces
{
    public interface IGenericGetByRepo<T> where T : BaseEntity
    {
        Task<T> GetByAsync(ISpecification<T>? specification = null);
    }
}