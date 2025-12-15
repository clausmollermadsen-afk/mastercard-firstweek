using Master.Firstweek.Client.Model;

namespace Master.Firstweek.Client.Test;

/// <summary>
/// Logger for requests and responses in tests. Serializes objects to formatted JSON.
/// </summary>
public class TestRequestResponseLogger : IRequestResponseLogger
{
    // Use indented JSON formatting for readability
    private static readonly System.Text.Json.JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    /// <summary>
    /// Logs the request and response objects as formatted JSON.
    /// </summary>
    public Task LogRequestResonseAsync<TRequest, TResponse>(TRequest request, TResponse response,
        ErrorResponse? errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        Console.WriteLine($"Request: {System.Text.Json.JsonSerializer.Serialize(request, JsonOptions)}");
        Console.WriteLine($"Response: {System.Text.Json.JsonSerializer.Serialize(response, JsonOptions)}");
        return Task.CompletedTask;
    }

    /// <summary>
    /// Logs the request and error response objects as formatted JSON.
    /// </summary>
    public Task LogRequestResonseAsync<TRequest>(TRequest request, ErrorResponse? errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class
    {
        Console.WriteLine($"Request: {System.Text.Json.JsonSerializer.Serialize(request, JsonOptions)}");
        Console.WriteLine($"Error: {System.Text.Json.JsonSerializer.Serialize(errorResponse, JsonOptions)}");
        return Task.CompletedTask;
    }
}