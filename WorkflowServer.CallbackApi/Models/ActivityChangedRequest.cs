namespace WorkflowServer.CallbackApi.Models;

public class ActivityChangedRequest : ProcessRequest
{
    public ActivityChangedRequest(Guid processId, string schemeCode, ProcessInstance processInstance, string previousActivityName, 
        string currentActivityName, string? token = null) 
        : base(processId, schemeCode, processInstance, token)
    {
        PreviousActivityName = previousActivityName;
        CurrentActivityName = currentActivityName;
    }
    
    public string PreviousActivityName { get; }
    public string CurrentActivityName { get; }
}