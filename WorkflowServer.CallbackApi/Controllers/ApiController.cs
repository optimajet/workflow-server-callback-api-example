using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WorkflowServer.CallbackApi.Models;
using WorkflowServer.CallbackApi.Workflow;

namespace WorkflowServer.CallbackApi.Controllers;

/// <summary>
/// This controller implements all possible requests from Callback API of Workflow Server 3.0.0.
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
        
        //The parameters will not be saved, this is an example. You should add the provider as a dependency injection.
        _parameterProvider = new ParameterProvider();
    }

    #region Actions & Conditions Execution

    /// <summary>
    /// Returns a list of actions that can be executed on the callback server.
    /// When the Workflow Server should execute an Action with a certain name,
    /// it calls the action execution method on the server that has returned this
    /// name in response to the request for the list of actions.
    /// </summary>
    [HttpGet]
    public Task<IActionResult> GetActions(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_actionProvider.ActionNames)));
    }

    /// <summary>
    /// Request to execute the action. Which of callback servers is called to execute this method, depends on the list of actions returned.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ExecuteAction(InstanceRequest request)
    {
        await _actionProvider.ExecuteAction(request.Name, request.Parameter, request.ProcessInstance);
        
        return Ok(ApiResponse.Ok());
    }

    /// <summary>
    /// Returns a list of conditions that can be executed on the callback server.
    /// When the Workflow Server should execute a condition with a certain name,
    /// it calls the condition execution method on the server that has returned
    /// this name in response to the request for the list of conditions.
    /// </summary>
    [HttpGet]
    public Task<IActionResult> GetConditions(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_conditionProvider.ConditionNames)));
    }

    /// <summary>
    /// Request to execute the condition. Which of the callback servers
    /// is called to execute this method, depends on the list of conditions returned.
    /// </summary>
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

    /// <summary>
    /// Returns a list of Authorization Rules that can be executed on the callback server.
    /// When the Workflow Server should execute an Authorization Rule with a certain name,
    /// it calls the Authorization Rule execution method on the server that has returned
    /// this name in response to the request for the list of Authorization Rules.
    /// </summary>
    [HttpGet]
    public Task<IActionResult> GetRules(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_identityProvider.RuleNames)));
    }

    /// <summary>
    /// Check if the User has the access to the command.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CheckRule(CheckRuleRequest request)
    {
        var result = await _identityProvider.RuleCheck(request.Name, request.IdentityId, request.Parameter, request.ProcessInstance);
        return Ok(ApiResponse.Ok(result));
    }

    /// <summary>
    /// Returns the list of all Users who have the access.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetIdentities(InstanceRequest request)
    {
        var result = await _identityProvider.RuleGet(request.Name, request.Parameter, request.ProcessInstance);
        return Ok(ApiResponse.Ok(result));
    }

    private readonly IdentityProvider _identityProvider;

    #endregion

    #region Remote Scheme Generation

    /// <summary>
    /// Workflow Engine (is a part of WorkflowServer) supports scheme generation. If you include this method, then,
    /// to initialize a new scheme, the Workflow Server calls it on all the connected
    /// servers with the settings containing the address of this method.
    /// </summary>
    [HttpPost]
    public Task<IActionResult> Generate(GenerateRequest request)
    {
        XmlDocument xml = new XmlDocument();
        
        //Your code
        
        return Task.FromResult<IActionResult>(Ok(xml.OuterXml));
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// The ProcessStatusChanged event is called only after switching to
    /// the statuses of Idled and Finalized. It is not called for subprocesses.
    /// </summary>
    [HttpPost]
    public Task<IActionResult> ProcessStatusChanged(StatusChangedRequest request)
    {
        _logger.LogInformation("Process status changed from {OldStatus} to {NewStatus}", 
            request.OldStatus, request.NewStatus);
        
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }
    
    /// <summary>
    /// The ProcessActivityChanged event.
    /// </summary>
    [HttpPost]
    public Task<IActionResult> ProcessActivityChanged(ActivityChangedRequest request)
    {
        _logger.LogInformation("Process activity changed from {PreviousActivityName} to {CurrentActivityName}", 
            request.PreviousActivityName, request.CurrentActivityName);
        
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }
    
    /// <summary>
    /// The processLogs event.
    /// </summary>
    [HttpPost]
    public Task<IActionResult> ProcessLog(LogRequest request)
    {
        //Your event actions
        
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok()));
    }

    #endregion

    #region Parameters Providing 
    
    /// <summary>
    /// Used to get parameters list.
    /// </summary>
    [HttpGet]
    public Task<IActionResult> GetParameterNames(string schemeCode, string token)
    {
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(_parameterProvider.GetNames)));
    }
    
    /// <summary>
    /// The method returns a JSON serialized parameter value.
    /// </summary>
    [HttpPost]
    public Task<IActionResult> GetParameter(ParameterRequest request)
    {
        var result = _parameterProvider.GetParameter(request.Name);
        return Task.FromResult<IActionResult>(Ok(ApiResponse.Ok(result)));
    }
    
    /// <summary>
    /// Used for set parameter value.
    /// </summary>
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