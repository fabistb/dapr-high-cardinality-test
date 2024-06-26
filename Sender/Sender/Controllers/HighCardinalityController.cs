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

    [HttpPost("service-invocation-dynamic-path")]
    public async Task ServiceInvocationDynamicPath()
    {
        await _serviceInvocationService.InvokeDynamicPathAsync();
    }

    [HttpPost("service-invocation-multiple-dynamic-values")]
    public async Task ServiceInvocationMultipleDynamic()
    {
        await _serviceInvocationService.InvokeMultipleAsync();
    }
}