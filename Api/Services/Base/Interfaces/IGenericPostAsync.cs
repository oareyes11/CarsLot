using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericPostAsync<TRequest,TResponse>
    {
        Task<IActionResult> PostAsync(TRequest request);
    }
}