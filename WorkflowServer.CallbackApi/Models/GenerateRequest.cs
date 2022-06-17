namespace WorkflowServer.CallbackApi.Models;

public class GenerateRequest
{
    public GenerateRequest(string schemeCode, Guid schemeId, object parameters, string scheme, string? token = null)
    {
        SchemeCode = schemeCode;
        SchemeId = schemeId;
        Parameters = parameters;
        Scheme = scheme;
        Token = token;
    }

    public string SchemeCode { get; }
    public Guid SchemeId { get; }
    public object Parameters { get; }
    public string Scheme { get; }
    public string? Token { get; }
}