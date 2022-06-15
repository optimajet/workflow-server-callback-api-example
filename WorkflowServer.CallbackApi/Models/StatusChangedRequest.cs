namespace WorkflowServer.CallbackApi.Models;

public class StatusChangedRequest : ProcessRequest
{
    public StatusChangedRequest(Guid processId, string schemeCode, ProcessInstance processInstance, string oldStatus, string newStatus, 
        string? token = null) 
        : base(processId, schemeCode, processInstance, token)
    {
        OldStatus = oldStatus;
        NewStatus = newStatus;
    }
    
    public string OldStatus { get; }
    public string NewStatus { get; }
}