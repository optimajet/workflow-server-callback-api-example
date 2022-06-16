using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WorkflowServer.CallbackApi.Models;
using WorkflowServer.CallbackApi.Workflow;

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

        _actionProvider = new ActionProvider();
        _conditionProvider = new ConditionProvider();
        _identityProvider = new IdentityProvider();
        _parameterProvider = new ParameterProvider();
    }

    #region Actions & Conditions Execution

    [HttpGet]
    public Task<IActionResult> GetActions(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_actionProvider.ActionNames)));
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteAction(InstanceRequest request)
    {
        await _actionProvider.ExecuteAction(request.Name, request.Parameter, request.ProcessInstance);
        
        return Ok(ApiResponse.Ok());
    }

    [HttpGet]
    public Task<IActionResult> GetConditions(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_conditionProvider.ConditionNames)));
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteCondition(InstanceRequest request)
    {
        var result = await _conditionProvider.ExecuteCondition(request.Name, request.Parameter, request.ProcessInstance);
        
        return Ok(ApiResponse.Ok(result));
    }

    private readonly ActionProvider _actionProvider;
    private readonly ConditionProvider _conditionProvider;

    #endregion

    #region Authorization Rules Execution

    [HttpGet]
    public Task<IActionResult> GetRules(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_identityProvider.RuleNames)));
    }

    [HttpPost]
    public async Task<IActionResult> CheckRule(CheckRuleRequest request)
    {
        var result = await _identityProvider.RuleCheck(request.Name, request.IdentityId, request.Parameter, request.ProcessInstance);
        return Ok(ApiResponse.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> GetIdentities(InstanceRequest request)
    {
        var result = await _identityProvider.RuleGet(request.Name, request.Parameter, request.ProcessInstance);
        return Ok(ApiResponse.Ok(result));
    }

    private readonly IdentityProvider _identityProvider;

    #endregion

    #region Remote Scheme Generation

    [HttpPost]
    public Task<IActionResult> Generate(GenerateRequest request)
    {
        XmlDocument xml = new XmlDocument();
        
        //Your code
        
        return Task.FromResult<IActionResult>(Ok(xml.OuterXml));
    }

    #endregion

    #region Event Handlers

    [HttpPost]
    public Task<IActionResult> ProcessStatusChanged(StatusChangedRequest request)
    {
        _logger.LogInformation("Process status changed from {OldStatus} to {NewStatus}", 
            request.OldStatus, request.NewStatus);
        
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }
    
    [HttpPost]
    public Task<IActionResult> ProcessActivityChanged(ActivityChangedRequest request)
    {
        _logger.LogInformation("Process activity changed from {PreviousActivityName} to {CurrentActivityName}", 
            request.PreviousActivityName, request.CurrentActivityName);
        
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }
    
    [HttpPost]
    public Task<IActionResult> ProcessLog(LogRequest request)
    {
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }

    #endregion

    #region Parameters Providing 
    
    [HttpGet]
    public Task<IActionResult> GetParameterNames(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_parameterProvider.GetNames)));
    }
    
    [HttpPost]
    public Task<IActionResult> GetParameter(ParameterRequest request)
    {
        var result = _parameterProvider.GetParameter(request.Name);
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(result)));
    }
    
    [HttpPost]
    public Task<IActionResult> SetParameter(ParameterRequest request)
    {
        _parameterProvider.SetParameter(request.Name, request.Value);
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }

    private readonly ParameterProvider _parameterProvider;

    #endregion

    private readonly ILogger<ApiController> _logger;
}