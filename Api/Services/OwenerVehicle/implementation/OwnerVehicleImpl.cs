
using Api.Casts.Request.OwnerVehicle;
using Api.Casts.Response.OwnerVehicle;
using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using Core.Tools.HttpResponse;
using DB.Entities;
using MapsterMapper;

namespace Api.Services.OwenerVehicle.implementation
{
    public class OwnerVehicleImpl : IGenericPostAsync<OwnerVehicleRequest, OwnerVehicleResponse>
    {
        private readonly IGenericPostRepo<OwnerVehicleEntity> _postOwnerVehicleRepo;
        private readonly IMapper _mapper;

        public OwnerVehicleImpl(IServiceProvider provider)
        {
            _postOwnerVehicleRepo = provider.GetRequiredService<IGenericPostRepo<OwnerVehicleEntity>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<ResponseSuccess<OwnerVehicleResponse>> PostAsync(OwnerVehicleRequest request)
        {
            OwnerVehicleEntity ownerVehicleRequest = _mapper.Map<OwnerVehicleEntity>(request);
            _ = await _postOwnerVehicleRepo.PostAsync(ownerVehicleRequest);
            OwnerVehicleResponse ownerVehicleResponse = new()
            {
                Saved = true
            };
            return new ResponseSuccess<OwnerVehicleResponse>(HttpEnums.OK, ownerVehicleResponse);

        }
    }
}