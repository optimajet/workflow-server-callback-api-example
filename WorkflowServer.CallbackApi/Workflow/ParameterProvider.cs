namespace WorkflowServer.CallbackApi.Workflow;

public class ParameterProvider
{
    public ParameterProvider()
    {
        Parameters = new Dictionary<string, object?>
        {
            ["MyParameter"] = string.Empty,
        };
    }

    public List<string> GetNames => new(Parameters.Keys);

    public object? GetParameter(string name)
    {
        var result = Parameters.TryGetValue(name, out object? value);
        return result ? value : null;
    }
    
    public void SetParameter(string name, object? value)
    {
        Parameters[name] = value;
    }

    private Dictionary<string, object?> Parameters { get; }
}