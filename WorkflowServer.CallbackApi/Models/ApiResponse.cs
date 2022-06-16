namespace WorkflowServer.CallbackApi.Models;

public class ApiResponse
{
    public static ApiResponse Ok(object? data = null) => new ApiResponse(true, data);
    public static ApiResponse Failure(string? error = null, string? message = null) => new ApiResponse(false, null, error, message);
    
    public ApiResponse(bool success, object? data = null, string? error = null, string? message = null)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    public string? Error { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public object? Data { get; set; }
}