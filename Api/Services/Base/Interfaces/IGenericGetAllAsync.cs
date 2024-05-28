using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericGetAllAsync<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}