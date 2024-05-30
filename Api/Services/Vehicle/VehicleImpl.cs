using Api.Casts.Request.Vehicle;
using Api.Casts.Response.Vehicle;
using Api.Services.Base.Interfaces;
using Core.Repository.Interfaces;
using Core.Tools.HttpResponse;
using DB.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> PostAsync(VehicleRequest request)
        {
            VehicleEntity vehicleRequest = _mapper.Map<VehicleEntity>(request);
            VehicleEntity vehicle = await _postVehicleRepo.PostAsync(vehicleRequest);
            VehicleResponse vehicleResponse = _mapper.Map<VehicleResponse>(vehicle);
            return new HttpDataResponse<VehicleResponse>(vehicleResponse).Success();


        }
    }
}