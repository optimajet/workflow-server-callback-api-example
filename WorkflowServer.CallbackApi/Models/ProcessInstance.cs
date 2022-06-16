namespace WorkflowServer.CallbackApi.Models;

public class ProcessInstance
{
    public Guid Id  { get; set; }
    public string? StateName { get; set; }
    public string? ActivityName { get; set; }
    public Guid? SchemeId { get; set; }
    public string? SchemeCode { get; set; }
    public string? PreviousState { get; set; }
    public string? PreviousStateForDirect { get; set; }
    public string? PreviousStateForReverse { get; set; }
    public string? PreviousActivity { get; set; }
    public string? PreviousActivityForDirect { get; set; }
    public string? PreviousActivityForReverse { get; set; }
    public Guid? ParentProcessId { get; set; }
    public Guid? RootProcessId { get; set; }
    public bool IsDeterminingParametersChanged { get; set; }
    public byte InstanceStatus { get; set; }
    public bool IsSubProcess { get; set; }
    public string? TenantId { get; set; }

    public List<TransitionItem>? Transitions { get; set; }
    public List<WorkflowServerProcessHistoryItem>? History { get; set; }
    public Dictionary<string, object>? ProcessParameters { get; set; }
    public List<Guid>? SubProcessIds { get; set; }
}