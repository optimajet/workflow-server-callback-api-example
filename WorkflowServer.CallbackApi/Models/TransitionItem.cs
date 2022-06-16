namespace WorkflowServer.CallbackApi.Models;

public class TransitionItem
{
    public Guid ProcessId { get; set; }
    public string? ActorIdentityId{ get; set; }
    public string? ExecutorIdentityId { get; set; }
    public string? FromActivityName { get; set; }
    public string? FromStateName { get; set; }
    public bool IsFinalised { get; set; }
    public string? ToActivityName{ get; set; }
    public string? ToStateName { get; set; }
    public string? TransitionClassifier { get; set; }
    public DateTime TransitionTime { get; set; }
    public string? TriggerName { get; set; }
}