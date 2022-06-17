namespace WorkflowServer.CallbackApi.Models;

public class CheckRuleRequest : InstanceRequest
{
    public CheckRuleRequest(string name, string parameter, ProcessInstance processInstance, string identityId, string? token = null) : 
        base(name, parameter, processInstance, token)
    {
        IdentityId = identityId;
    }
    
    public string IdentityId { get; }
}