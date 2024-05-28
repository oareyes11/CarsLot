using DB.Entities;

namespace Core.Repository.Interfaces
{
    public interface IGenericPutRepo<T> where T : BaseEntity
    {
        Task<T> PutAsync(T request);
    }
}