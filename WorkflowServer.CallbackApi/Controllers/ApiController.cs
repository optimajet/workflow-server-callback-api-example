using Microsoft.AspNetCore.Mvc;

namespace WorkflowServer.CallbackApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ApiController : ControllerBase
{
    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }

    private readonly ILogger<ApiController> _logger;
}