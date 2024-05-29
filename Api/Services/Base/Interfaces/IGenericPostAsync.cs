using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericPostAsync<TRequest,TResponse>
    {
        Task<TResponse> PostAsync(TRequest request);
    }
}