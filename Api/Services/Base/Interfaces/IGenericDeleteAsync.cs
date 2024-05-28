using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericDeleteAsync<T> where T : BaseEntity
    {
        Task<T> DeleteAsync(T request);
    }
}