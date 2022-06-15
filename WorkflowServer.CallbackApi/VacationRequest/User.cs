namespace WorkflowServer.CallbackApi.VacationRequest;

public class User
{
    public User(string id, string name, params string[] roles)
    {
        Id = id;
        Name = name;
        Roles = roles;
    }

    public string Id { get; }
    public string Name { get; }
    public string[] Roles { get; }
}