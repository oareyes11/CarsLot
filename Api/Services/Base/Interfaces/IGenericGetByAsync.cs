using DB.Entities;

namespace Api.Services.Base.Interfaces
{
    public interface IGenericGetByAsync<T,F> where T : BaseEntity
    {
        Task<T> GetByAsync(F filter);
        
    }
}