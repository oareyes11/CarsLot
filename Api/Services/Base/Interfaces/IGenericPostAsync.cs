using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericPostAsync<T> where T : BaseEntity
    {
        Task<T> PostAsync(T request);
    }
}