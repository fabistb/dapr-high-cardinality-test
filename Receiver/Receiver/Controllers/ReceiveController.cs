using Microsoft.AspNetCore.Mvc;

namespace Receiver.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiveController : ControllerBase
{
    [HttpPost("{id}")]
    public async Task<IActionResult> Response([FromRoute] string id)
    {
        return new OkObjectResult(id);
    }

    [HttpPost("{id}/value")]
    public async Task<IActionResult> ResponseValue([FromRoute] string id)
    {
        return new OkObjectResult(id);
    }
}