namespace WorkflowServer.CallbackApi.Models;

public class LogRequest
{
    public LogRequest(List<object> processLogs, string? token = null)
    {
        ProcessLogs = processLogs;
        Token = token;
    }

    public List<object> ProcessLogs { get; }
    public string? Token { get; }
}