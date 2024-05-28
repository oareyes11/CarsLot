
using Api.Controllers.Base;
using Api.Services.Base.Interfaces;
using DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Owner
{
    public class OwnerController : BaseApiController
    {
        private readonly IGenericPostAsync<OwnerEntity> _postOwnerService;

        public OwnerController(IServiceProvider provider)
        {
            _postOwnerService = provider.GetRequiredService<IGenericPostAsync<OwnerEntity>>();
        }

        [HttpPost]
        public async Task<OwnerEntity> PostUser([FromBody] OwnerEntity request)
        {
            return await _postOwnerService.PostAsync(request);
        }

    }
}