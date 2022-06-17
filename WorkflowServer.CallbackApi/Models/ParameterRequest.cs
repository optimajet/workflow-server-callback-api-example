namespace WorkflowServer.CallbackApi.Models;

public class ParameterRequest : ProcessRequest
{
    public ParameterRequest(Guid processId, string schemeCode, ProcessInstance processInstance, string name, 
        object? value = null, string? token = null) 
        : base(processId, schemeCode, processInstance, token)
    {
        Name = name;
        Value = value;
    }
    
    public string Name { get; }
    public object? Value { get; }
}