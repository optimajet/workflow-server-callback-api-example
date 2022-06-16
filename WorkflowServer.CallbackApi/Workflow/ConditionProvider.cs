using System.Collections.ObjectModel;
using WorkflowServer.CallbackApi.Models;

namespace WorkflowServer.CallbackApi.Workflow;

public class ConditionProvider
{
    public delegate Task<bool> Condition(string parameter, ProcessInstance processInstance);

    public ConditionProvider()
    {
        Conditions = new ReadOnlyDictionary<string, Condition>(new Dictionary<string, Condition>
        {
            [nameof(MyCondition)] = MyCondition,
        });
    }

    public ReadOnlyDictionary<string, Condition> Conditions { get; }

    public List<string> ConditionNames => new(Conditions.Keys);

    public async Task<bool> ExecuteCondition(string name, string parameter, ProcessInstance processInstance) => await Conditions[name](parameter, processInstance);

    public Task<bool> MyCondition(string parameter, ProcessInstance processInstance)
    {
        return Task.FromResult(true);
    }
}