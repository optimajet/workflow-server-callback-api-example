using Microsoft.AspNetCore.Mvc;

namespace WorkflowServer.CallbackApi.Controllers;

//TODO Сделать модели для получения и ответов

/// <summary>
/// This controller implements all possible requests from Callback API of WFS 3.0.0.
/// Callback API allows hosting your code of Actions, Conditions or Rules on third-party servers.
/// Callback server should be connected in the admin panel on the Callback API page.
/// More details on the  <see href="https://workflowserver.io/documentation/callback-api">workflowserver.io</see>
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class ApiController : ControllerBase
{
    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }

    #region Actions & Conditions Execution

    [HttpGet]
    public async Task<IActionResult> GetActions(string schemeCode)
    {
        // var actions = new List<string> { "Action4", "Action5", "Action6" };
        // var res = new CallBackResponse { success = true, data = actions };
        //
        // return Ok(res);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteAction()
    {
        // return Ok(new CallBackResponse());
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetConditions(string schemeCode)
    {
        // var conditions = new List<string> { "IsTeamleader", "IsManager", "IsUser" };
        // var res = new CallBackResponse { success = true, data = conditions };
        // return Ok(res);
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteCondition()
    {
        // var processInstance = JsonConvert.DeserializeObject<dynamic>(wfQuery.processInstance.ToString());
        // string creatorId = processInstance.ProcessParameters.creatorIdentity;
        // if (wfQuery.name == "IsUser")
        // {
        //     var isInRole = IsInRole(creatorId, "user");
        //     if (isInRole)
        //     {
        //         return Ok(new CallBackResponse { success = true, data = true });
        //     }
        //     else
        //     {
        //         return Ok(new CallBackResponse { success = true, data = false });
        //     }
        // }
        // else if (wfQuery.name == "IsTeamleader")
        // {
        //     var isInRole = IsInRole(creatorId, "teamleader");
        //     if (isInRole)
        //     {
        //         return Ok(new CallBackResponse { success = true, data = true });
        //     }
        //     else
        //     {
        //         return Ok(new CallBackResponse { success = true, data = false });
        //     }
        // }
        // else if (wfQuery.name == "IsManager")
        // {
        //     var isInRole = IsInRole(creatorId, "manager");
        //     if (isInRole)
        //     {
        //         return Ok(new CallBackResponse { success = true, data = true });
        //     }
        //     else
        //     {
        //         return Ok(new CallBackResponse { success = true, data = false });
        //     }
        // }
        // else
        // {
        //     return Ok(new CallBackResponse { success = true, data = false });
        // }
        
        return Ok();
    }

    #endregion

    #region Authorization Rules Execution

    [HttpGet]
    public async Task<IActionResult> GetRules(string schemeCode)
    {
        // var rules = new List<string> { "CheckRoleCallBack" };
        // return Ok(new CallBackResponse { success = true, data = rules });
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CheckRule()
    {
        // if (wfQueryRule.name == "CheckRoleCallBack")
        // {
        //     string? roleName = wfQueryRule.parameter;
        //     string? userId = wfQueryRule.identityId;
        //     var res = IsInRole(userId, roleName);
        //     return Ok(new CallBackResponse { success = true, data = res });
        // }
        //
        // return Ok(new CallBackResponse { success = true, data = false });
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> GetIdentities()
    {
        // var temp = JsonConvert.DeserializeObject<dynamic>(wfQuery.processInstance.ToString());
        // //var id = temp.Id;
        //
        // var users = UsersInRole(wfQuery.parameter);
        // return Ok(new CallBackResponse { success = true, data = users });
        
        return Ok();
    }

    #endregion

    #region Remote Scheme Generation

    [HttpPost]
    public async Task<IActionResult> Generate()
    {
        return Ok();
    }

    #endregion

    #region Event Handlers

    [HttpPost]
    public async Task<IActionResult> ProcessStatusChanged()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> ProcessActivityChanged()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> ProcessLog()
    {
        return Ok();
    }

    #endregion

    #region Parameters Providing 
    
    [HttpPost]
    public async Task<IActionResult> GetParameterNames(string schemeCode)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetParameter()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> SetParameter()
    {
        return Ok();
    }

    #endregion

    private readonly ILogger<ApiController> _logger;
}