using Api.Casts.Request.Vehicle;
using Api.Casts.Response.Vehicle;
using Api.Controllers.Base;
using Api.Services.Base.Interfaces;
using Core.Tools.HttpResponse;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.Vehicle
{
    public class VehicleController : BaseApiController
    {
        private readonly IGenericPostAsync<VehicleRequest, VehicleResponse> _postVehicleService;
        public VehicleController(IServiceProvider provider)
        {
            _postVehicleService = provider.GetRequiredService<IGenericPostAsync<VehicleRequest, VehicleResponse>>();
        }
        [HttpPost()]
        public async Task<ResponseSuccess<VehicleResponse>> PostUser([FromBody] VehicleRequest request)
        {
            ResponseSuccess<VehicleResponse>? vehicle = await _postVehicleService.PostAsync(request);
            return vehicle;
        }
    }
}