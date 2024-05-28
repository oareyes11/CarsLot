

using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using DB.Entities;

namespace Api.Services.Owner.Implementation
{
    public class OwnerImpl : IGenericPostAsync<OwnerEntity>
    {
        private readonly IGenericPostRepo<OwnerEntity> _postOwnerRepo;
        public OwnerImpl(IServiceProvider provider)
        {
            _postOwnerRepo = provider.GetRequiredService<IGenericPostRepo<OwnerEntity>>();
        }
        public async Task<OwnerEntity> PostAsync(OwnerEntity request)
        {
            OwnerEntity ownerEntity = await _postOwnerRepo.PostAsync(request);
            return ownerEntity;
        }
    }
}