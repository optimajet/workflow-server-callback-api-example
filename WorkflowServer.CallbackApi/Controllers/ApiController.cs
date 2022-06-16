using System.Text;
using Microsoft.AspNetCore.Mvc;
using WorkflowServer.CallbackApi.Models;

namespace WorkflowServer.CallbackApi.Controllers;

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
    public async Task<IActionResult> GetActions(string schemeCode, string token)
    {
        // var actions = new List<string> { "Action4", "Action5", "Action6" };
        // var res = new CallBackResponse { success = true, data = actions };
        //
        // return Ok(res);

        return Ok(ApiResponse.Ok(new List<string>()));
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteAction(InstanceRequest request)
    {
        // return Ok(new CallBackResponse());
        
        return Ok(ApiResponse.Ok());
    }

    [HttpGet]
    public async Task<IActionResult> GetConditions(string schemeCode, string token)
    {
        // var conditions = new List<string> { "IsTeamleader", "IsManager", "IsUser" };
        // var res = new CallBackResponse { success = true, data = conditions };
        // return Ok(res);
        
        return Ok(ApiResponse.Ok(new List<string>()));
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteCondition(InstanceRequest request)
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
        
        return Ok(ApiResponse.Ok(true));
    }

    #endregion

    #region Authorization Rules Execution

    [HttpGet]
    public async Task<IActionResult> GetRules(string schemeCode, string token)
    {
        // var rules = new List<string> { "CheckRoleCallBack" };
        // return Ok(new CallBackResponse { success = true, data = rules });
        
        return Ok(ApiResponse.Ok(new List<string>()));
    }

    [HttpPost]
    public async Task<IActionResult> CheckRule(CheckRuleRequest request)
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
        
        return Ok(ApiResponse.Ok(true));
    }

    [HttpPost]
    public async Task<IActionResult> GetIdentities(InstanceRequest request)
    {
        // var temp = JsonConvert.DeserializeObject<dynamic>(wfQuery.processInstance.ToString());
        // //var id = temp.Id;
        //
        // var users = UsersInRole(wfQuery.parameter);
        // return Ok(new CallBackResponse { success = true, data = users });
        
        return Ok(ApiResponse.Ok(new List<string>()));
    }

    #endregion

    #region Remote Scheme Generation

    [HttpPost]
    public async Task<IActionResult> Generate(GenerateRequest request)
    {
        return Ok("<xml/>");
    }

    #endregion

    #region Event Handlers

    [HttpPost]
    public async Task<IActionResult> ProcessStatusChanged(StatusChangedRequest request)
    {
        return Ok(ApiResponse.Ok());
    }
    
    [HttpPost]
    public async Task<IActionResult> ProcessActivityChanged(ActivityChangedRequest request)
    {
        return Ok(ApiResponse.Ok());
    }
    
    [HttpPost]
    public async Task<IActionResult> ProcessLog(LogRequest request)
    {
        using var sr = new StreamReader(Request.Body);
        var txt = await sr.ReadToEndAsync();
        
        return Ok(ApiResponse.Ok());
    }

    #endregion

    #region Parameters Providing 
    
    [HttpGet]
    public async Task<IActionResult> GetParameterNames(string schemeCode, string token)
    {
        return Ok(ApiResponse.Ok(new List<string>()));
    }
    
    [HttpPost]
    public async Task<IActionResult> GetParameter(ParameterRequest request)
    {
        return Ok(ApiResponse.Ok(new()));
    }
    
    [HttpPost]
    public async Task<IActionResult> SetParameter(ParameterRequest request)
    {
        return Ok(ApiResponse.Ok());
    }

    #endregion

    private readonly ILogger<ApiController> _logger;
}