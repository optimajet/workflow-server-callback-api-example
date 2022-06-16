namespace WorkflowServer.CallbackApi.Models;

public class CheckRuleRequest : InstanceRequest
{
    public CheckRuleRequest(string name, string parameter, string token, ProcessInstance processInstance, string identityId) : 
        base(name, parameter, token, processInstance)
    {
        IdentityId = identityId;
    }
    
    public string IdentityId { get; }
}