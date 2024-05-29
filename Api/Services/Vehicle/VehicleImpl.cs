using Api.Casts.Reqest.Vehicle;
using Api.Casts.Response.Vehicle;
using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using DB.Entities;
using MapsterMapper;
namespace Api.Services.Vehicle
{
    public class VehicleImpl : IGenericPostAsync<VehicleRequest, VehicleResponse>
    {
        private readonly IGenericPostRepo<VehicleEntity> _postVehicleRepo;
        private readonly IMapper _mapper;
        public VehicleImpl(IServiceProvider provider)
        {
            _postVehicleRepo = provider.GetRequiredService<IGenericPostRepo<VehicleEntity>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }
        public async Task<VehicleResponse> PostAsync(VehicleRequest request)
        {
            VehicleEntity vehicleRequest = _mapper.Map<VehicleEntity>(request);
            VehicleEntity vehicle = await _postVehicleRepo.PostAsync(vehicleRequest);
            VehicleResponse vehicleResponse = _mapper.Map<VehicleResponse>(vehicle);
            return vehicleResponse;
        }
    }
}