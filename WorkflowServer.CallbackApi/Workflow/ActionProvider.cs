using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
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
            [nameof(JsonBackup)] = JsonBackup,
        });
    }

    public ReadOnlyDictionary<string, Action> Actions { get; }

    public List<string> ActionNames => new(Actions.Keys);

    public async Task ExecuteAction(string name, string parameter, ProcessInstance processInstance) => await Actions[name](parameter, processInstance);

    public Task MyAction(string parameter, ProcessInstance processInstance)
    {
        return Task.CompletedTask;
    }
    
    public async Task JsonBackup(string parameter, ProcessInstance processInstance)
    {
        if (string.IsNullOrWhiteSpace(parameter)) parameter = "backup";
        var filename = $"{parameter.Trim()}_{processInstance.Id}_{DateTime.Now.ToString("yyyy-MM-dd")}.json";

        var path = Path.Combine(Environment.CurrentDirectory, "backups");

        Directory.CreateDirectory(path);
        
        path = Path.Combine(path, filename);

        await using var fs = File.Create(path);

        await fs.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(processInstance)));
    }
}