using Core.Tools.HttpResponse;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericPostAsync<TRequest,TResponse>
    {
        Task<ResponseSuccess<TResponse>> PostAsync(TRequest request);
    }
}