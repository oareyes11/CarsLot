using Api.Casts.Request.OwnerVehicle;
using Api.Casts.Response.OwnerVehicle;
using Api.Controllers.Base;
using Api.Services.Base.Interfaces;
using Core.Tools.HttpResponse;
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
        public async Task<ResponseSuccess<OwnerVehicleResponse>> PostUser([FromBody] OwnerVehicleRequest request)
        {
            ResponseSuccess<OwnerVehicleResponse>? ownerVehicle = await _postOwnerService.PostAsync(request);
            return ownerVehicle;
        }
    }
}