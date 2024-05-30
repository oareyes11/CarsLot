using Api.Casts.Request.OwnerVehicle;
using Api.Casts.Response.OwnerVehicle;
using Api.Controllers.Base;
using Api.Services.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.OwnerVehicle
{
    public class OwnerVehicleController : BaseApiController
    {
        private readonly IGenericPostAsync<OwnerVehicleRequest, OwnerVehicleResponse> _postOwnerService;
        public OwnerVehicleController(IServiceProvider provider)
        {
            _postOwnerService = provider.GetRequiredService<IGenericPostAsync<OwnerVehicleRequest, OwnerVehicleResponse>>();
        }
        [HttpPost()]
        public async Task<ActionResult<OwnerVehicleResponse>> PostUser([FromBody] OwnerVehicleRequest request)
        {
            OwnerVehicleResponse? ownerVehicle = await _postOwnerService.PostAsync(request);
            return Ok(ownerVehicle);
        }
    }
}