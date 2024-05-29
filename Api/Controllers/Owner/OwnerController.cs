
using Api.Controllers.Base;
using Api.Filters.Base;
using Api.Services.Base.Interfaces;
using DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Owner
{
    public class OwnerController : BaseApiController
    {
        private readonly IGenericPostAsync<OwnerEntity> _postOwnerService;
        private readonly IGenericGetByAsync<OwnerEntity, EmailFilter> _getByEmailOwnerService;

        public OwnerController(IServiceProvider provider)
        {
            _postOwnerService = provider.GetRequiredService<IGenericPostAsync<OwnerEntity>>();
            _getByEmailOwnerService = provider.GetRequiredService<IGenericGetByAsync<OwnerEntity, EmailFilter>>();
        }

        [HttpPost]
        public async Task<OwnerEntity> PostUser([FromBody] OwnerEntity request)
        {
            return await _postOwnerService.PostAsync(request);
        }

        [HttpPost("/login")]
        public async Task<ActionResult<OwnerEntity>> GetUsersByEmail(EmailFilter email)
        {
            OwnerEntity? owner = await _getByEmailOwnerService.GetByAsync(email);
            return Ok(owner);
        }

    }
}