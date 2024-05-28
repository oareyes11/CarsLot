
using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericGetByIdAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
    }
}