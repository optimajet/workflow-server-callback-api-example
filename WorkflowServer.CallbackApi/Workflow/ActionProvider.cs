using System.Collections.ObjectModel;
using WorkflowServer.CallbackApi.Models;

namespace WorkflowServer.CallbackApi.Workflow;

public class ActionProvider
{
    public delegate Task Action(string parameter, ProcessInstance processInstance);

    public ActionProvider()
    {
        Actions = new ReadOnlyDictionary<string, Action>(new Dictionary<string, Action>
        {
            [nameof(MyAction)] = MyAction,
        });
    }

    public ReadOnlyDictionary<string, Action> Actions { get; }

    public List<string> ActionNames => new(Actions.Keys);

    public async Task ExecuteAction(string name, string parameter, ProcessInstance processInstance) => await Actions[name](parameter, processInstance);

    public Task MyAction(string parameter, ProcessInstance processInstance)
    {
        return Task.CompletedTask;
    }
}