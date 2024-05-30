using Api.Casts.Request.Owner;
using Api.Casts.Response.Owner;
using Api.Filters.Base;
using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using DB.Entities;
using MapsterMapper;
namespace Api.Services.Owner.Implementation
{
    public class OwnerImpl : IGenericPostAsync<OwnerRequest,OwnerResponse>, IGenericGetByAsync<OwnerEntity, EmailFilter>
    {
        private readonly IGenericPostRepo<OwnerEntity> _postOwnerRepo;
        private readonly IGenericGetByRepo<OwnerEntity> _getByOwnerRepo;
        private readonly ISpecification<OwnerEntity> _specifications;
        private readonly IMapper _mapper;
        public OwnerImpl(IServiceProvider provider)
        {
            _postOwnerRepo = provider.GetRequiredService<IGenericPostRepo<OwnerEntity>>();
            _getByOwnerRepo = provider.GetRequiredService<IGenericGetByRepo<OwnerEntity>>();
            _specifications = provider.GetRequiredService<ISpecification<OwnerEntity>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }
        public async Task<OwnerEntity> GetByAsync(EmailFilter filter)
        {
            _specifications.AddCriterial(x => x.Email == filter.Email);
            return await _getByOwnerRepo.GetByAsync(_specifications);
        }
        public async Task<OwnerResponse> PostAsync(OwnerRequest request)
        {
            OwnerEntity ownerRequest = _mapper.Map<OwnerEntity>(request);
            OwnerEntity? owner = await _postOwnerRepo.PostAsync(ownerRequest);
            OwnerResponse ownerResponse = _mapper.Map<OwnerResponse>(owner);
            return ownerResponse;
        }
    }
}