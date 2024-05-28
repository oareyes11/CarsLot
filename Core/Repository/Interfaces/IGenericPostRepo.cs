using DB.Entities;
namespace Core.Repository.Interfaces
{
    public interface IGenericPostRepo<T> where T : BaseEntity
    {
        Task<T> PostAsync(T request);
    }
}