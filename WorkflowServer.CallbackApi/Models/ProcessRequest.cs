namespace WorkflowServer.CallbackApi.Models;

public class ProcessRequest
{
    public ProcessRequest(Guid processId, string schemeCode, ProcessInstance processInstance, string token)
    {
        ProcessId = processId;
        SchemeCode = schemeCode;
        ProcessInstance = processInstance;
        Token = token;
    }

    public Guid ProcessId { get; }
    public string SchemeCode { get; }
    public ProcessInstance ProcessInstance { get; }
    public string Token { get; }
}