using Api.Casts.Reqest.Vehicle;
using Api.Casts.Response.Vehicle;
using Api.Controllers.Base;
using Api.Services.Base.Interfaces;
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
        public async Task<ActionResult<VehicleResponse>> PostUser([FromBody] VehicleRequest request)
        {
            VehicleResponse? vehicle = await _postVehicleService.PostAsync(request);
            return Ok(vehicle);
        }
    }
}