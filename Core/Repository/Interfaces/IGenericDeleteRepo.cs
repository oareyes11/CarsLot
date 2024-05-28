using DB.Entities;

namespace Core.Repository.Interfaces
{
    public interface IGenericDeleteRepo<T> where T : BaseEntity
    {
        Task<T> DeleteAsync(T request);
    }
}