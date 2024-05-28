using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericPutAsync<T> where T : BaseEntity
    {
        Task<T> PutAsync(T request);

    }
}