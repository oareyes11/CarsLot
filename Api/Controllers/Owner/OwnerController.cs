using Api.Casts.Request.Owner;
using Api.Casts.Response.Owner;
using Api.Controllers.Base;
using Api.Filters.Base;
using Api.Services.Base.Interfaces;
using DB.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.Owner
{
    public class OwnerController : BaseApiController
    {
        private readonly IGenericPostAsync<OwnerRequest,OwnerResponse> _postOwnerService;
        private readonly IGenericGetByAsync<OwnerEntity, EmailFilter> _getByEmailOwnerService;
        public OwnerController(IServiceProvider provider)
        {
            _postOwnerService = provider.GetRequiredService<IGenericPostAsync<OwnerRequest,OwnerResponse>>();
            _getByEmailOwnerService = provider.GetRequiredService<IGenericGetByAsync<OwnerEntity, EmailFilter>>();
        }
        [HttpPost("/api/sign-up")]
        public async Task<ActionResult<OwnerEntity>> PostUser([FromBody] OwnerRequest request)
        {
            OwnerResponse? owner = await _postOwnerService.PostAsync(request);
            return Ok(owner);
        }
        [HttpPost("/api/login")]
        public async Task<ActionResult<OwnerEntity>> GetUsersByEmail(EmailFilter email)
        {
            OwnerEntity? owner = await _getByEmailOwnerService.GetByAsync(email);
            return Ok(owner);
        }
    }
}