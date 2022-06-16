using WorkflowServer.CallbackApi.Models;

namespace WorkflowServer.CallbackApi.Workflow;

public class Rule
{
    public delegate Task<bool> Check(string identityId, string parameter, ProcessInstance processInstance);
    public delegate Task<IEnumerable<string>> Get(string parameter, ProcessInstance processInstance);

    public Rule(Check checkFunction, Get getFunction)
    {
        CheckFunction = checkFunction;
        GetFunction = getFunction;
    }

    public Check CheckFunction { get; }
    public Get GetFunction { get; }
    
}