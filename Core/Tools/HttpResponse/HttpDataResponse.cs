using Microsoft.AspNetCore.Mvc;
namespace Core.Tools.HttpResponse
{
    public class HttpDataResponse<TResponse> : ControllerBase
    {
        public HttpDataResponse()
        {
        }
        public HttpDataResponse(TResponse data)
        {
            Data = data;
        }
        public TResponse Data { get; set; } = default(TResponse)!;
        public IActionResult Success()
        {
            return Ok(Data);
        }
        public IActionResult ErrorRequest()
        {
            return BadRequest("Bad Request");
        }
        public IActionResult UserUnauthorized()
        {
            return Unauthorized("User Unauthorized");
        }
        public IActionResult EmptyData()
        {
            return NotFound(Data);
        }
        public IActionResult Problem()
        {
            return Conflict("We have a conflict");
        }
    }
}