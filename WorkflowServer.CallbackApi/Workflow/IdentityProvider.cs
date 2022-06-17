using System.Collections.ObjectModel;
using WorkflowServer.CallbackApi.Models;
using WorkflowServer.CallbackApi.VacationRequest;

namespace WorkflowServer.CallbackApi.Workflow;

public class IdentityProvider
{
    public IdentityProvider()
    {
        Rules = new ReadOnlyDictionary<string, Rule>(new Dictionary<string, Rule>
        {
            ["MyRule"] = new(MyRuleCheck, MyRuleGet),
            ["InRole"] = new(InRoleCheck, InRoleGet),
            ["isUser"] = new(IsUserCheck, IsUserGet),
        });

        _users = new List<User>
        {
            new("John", "John", "User"),
            new("Margo", "Margo", "User"),
            new("Maria", "Maria", "User", "Accountant"),
            new("Mark", "Mark", "User"),
            new("Max", "Max", "User"),
            new("Silviya", "Silviya", "User", "Big Boss"),
        };
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
    
    public Task<bool> InRoleCheck(string identityId, string parameter, ProcessInstance processInstance)
    {
        var result = _users.Any(u => u.Id == identityId && u.Roles.Contains(parameter));
        return Task.FromResult(result);
    }
    
    public Task<IEnumerable<string>> InRoleGet(string parameter, ProcessInstance processInstance)
    {
        var result = _users.Where(u => u.Roles.Contains(parameter)).Select(u => u.Name);
        return Task.FromResult(result);
    }
    
    public Task<bool> IsUserCheck(string identityId, string parameter, ProcessInstance processInstance)
    {
        var result = _users.Any(u => u.Id == identityId && u.Name == parameter);
        return Task.FromResult(result);
    }
    
    public Task<IEnumerable<string>> IsUserGet(string parameter, ProcessInstance processInstance)
    {
        var result = _users.Where(u => u.Name == parameter).Select(u => u.Name);
        return Task.FromResult(result);
    }

    private readonly List<User> _users;
}