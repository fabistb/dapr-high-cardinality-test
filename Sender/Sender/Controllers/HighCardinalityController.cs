using Microsoft.AspNetCore.Mvc;
using Sender.Services;

namespace Sender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HighCardinalityController : ControllerBase
{
    private readonly IServiceInvocationService _serviceInvocationService;

    public HighCardinalityController(IServiceInvocationService serviceInvocationService)
    {
        _serviceInvocationService = serviceInvocationService;
    }
    
    [HttpPost("service-invocation")]
    public async Task ServiceInvocation()
    {
        await _serviceInvocationService.InvokeAsync();
    }
}