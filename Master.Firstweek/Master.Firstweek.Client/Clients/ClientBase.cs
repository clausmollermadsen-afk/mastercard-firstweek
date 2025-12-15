using Master.Firstweek.Client.Model;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Master.Firstweek.Client.Clients;

/// <summary>
/// Provides a base class for Mastercard API clients, encapsulating common functionality for executing API calls and logging errors.
/// </summary>
public class ClientBase
{
    private readonly ILogger<ClientBase> _logger;
    private readonly RestClient _restClient;
    private readonly IRequestResponseLogger _requestResponseLogger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientBase"/> class.
    /// </summary>
    /// <param name="logger">The logger instance for logging errors and information.</param>
    /// <param name="restClient">The RestClient instance used for making HTTP requests.</param>
    protected ClientBase(RestClient restClient, IRequestResponseLogger requestResponseLogger,  ILogger<ClientBase> logger)
    {
        _logger = logger;
        _requestResponseLogger = requestResponseLogger;
        _restClient = restClient;
    }

    /// <summary>
    /// Executes an asynchronous API call using the provided RestRequest and handles error logging and deserialization.
    /// </summary>
    /// <typeparam name="TResponse">The type of the expected successful response.</typeparam>
    /// <param name="request">The RestRequest to execute.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{TResponse, ErrorResponse}"/> containing either the successful response or an error response.
    /// </returns>
    /// <exception cref="Exception">Thrown when the API call fails and no error response can be deserialized.</exception>
    protected async Task<Either<TResponse, ErrorResponse>> ExecuteAsync<TResponse>(RestRequest request, CancellationToken cancellationToken)
    {
        var restResponse = await _restClient.ExecuteAsync<TResponse>(request, cancellationToken);

        if (restResponse.IsSuccessful)
        {
            await _requestResponseLogger.LogRequestResonseAsync(request, restResponse, null, cancellationToken);
            return new Either<TResponse, ErrorResponse>(restResponse.Data!);
        }

        var errorResponse = restResponse.Content != null
            ? System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(restResponse.Content)
            : null;

        if (errorResponse != null)
        {
            await _requestResponseLogger.LogRequestResonseAsync(request, errorResponse, cancellationToken);
            return new Either<TResponse, ErrorResponse>(errorResponse);
        }

        _logger.LogError("Error occurred while executing API call. Status Code: {StatusCode}, Content: {Content}",
            restResponse.StatusCode, restResponse.Content);
        throw new Exception($"API call failed with status code {restResponse.StatusCode}");
    }
}
