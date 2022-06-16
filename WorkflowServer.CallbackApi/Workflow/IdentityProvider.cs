using System.Collections.ObjectModel;
using WorkflowServer.CallbackApi.Models;

namespace WorkflowServer.CallbackApi.Workflow;

public class IdentityProvider
{
    public IdentityProvider()
    {
        Rules = new ReadOnlyDictionary<string, Rule>(new Dictionary<string, Rule>
        {
            ["MyRule"] = new(MyRuleCheck, MyRuleGet)
        });
    }

    public ReadOnlyDictionary<string, Rule> Rules { get; }

    public List<string> RuleNames => new(Rules.Keys);

    public async Task<bool> RuleCheck(string name, string identityId, string parameter, ProcessInstance processInstance) => 
        await Rules[name].CheckFunction(identityId, parameter, processInstance);
    
    public async Task<IEnumerable<string>> RuleGet(string name, string parameter, ProcessInstance processInstance) => 
        await Rules[name].GetFunction(parameter, processInstance);
    
    public static Task<bool> MyRuleCheck(string identityId, string parameter, ProcessInstance processInstance)
    {
        return Task.FromResult(true);
    }
    
    public static Task<IEnumerable<string>> MyRuleGet(string parameter, ProcessInstance processInstance)
    {
        return Task.FromResult<IEnumerable<string>>(Array.Empty<string>());
    }
}