using Api.Filters.Base;
using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using DB.Entities;
namespace Api.Services.Owner.Implementation
{
    public class OwnerImpl : IGenericPostAsync<OwnerEntity>, IGenericGetByAsync<OwnerEntity, EmailFilter>
    {
        private readonly IGenericPostRepo<OwnerEntity> _postOwnerRepo;
        private readonly IGenericGetByRepo<OwnerEntity> _getByOwnerRepo;
        private readonly ISpecification<OwnerEntity> _specifications;
        public OwnerImpl(IServiceProvider provider)
        {
            _postOwnerRepo = provider.GetRequiredService<IGenericPostRepo<OwnerEntity>>();
            _getByOwnerRepo = provider.GetRequiredService<IGenericGetByRepo<OwnerEntity>>();
            _specifications = provider.GetRequiredService<ISpecification<OwnerEntity>>();
        }
        public async Task<OwnerEntity> GetByAsync(EmailFilter filter)
        {
            _specifications.AddCriterial(x => x.Email == filter.Email);
            return await _getByOwnerRepo.GetByAsync(_specifications);
        }
        public async Task<OwnerEntity> PostAsync(OwnerEntity request)
        {
            OwnerEntity ownerEntity = await _postOwnerRepo.PostAsync(request);
            return ownerEntity;
        }
    }
}