namespace WorkflowServer.CallbackApi.Models;

public class InstanceRequest
{
    public InstanceRequest(string name, string parameter, string token, ProcessInstance processInstance)
    {
        Name = name;
        Parameter = parameter;
        Token = token;
        ProcessInstance = processInstance;
    }

    public string Name { get; }
    public string Parameter { get; }
    public ProcessInstance ProcessInstance { get; }
    public string Token { get; }
}