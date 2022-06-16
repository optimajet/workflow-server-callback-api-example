namespace WorkflowServer.CallbackApi.Models;

public class WorkflowServerProcessHistoryItem
{
    public Guid Id { get; set; }
    public Guid ProcessId { get; set; }
    public string? IdentityId { get; set; }
    public string? AllowedToEmployeeNames { get; set; }
    public DateTime? TransitionTime { get; set; }
    public long Order { get; set; }
    public string? InitialState { get; set; }
    public string? DestinationState { get; set; }
    public string? Command { get; set; }
}