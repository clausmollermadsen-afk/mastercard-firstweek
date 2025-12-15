using Master.Firstweek.Client.Model;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Master.Firstweek.Client.Clients;

/// <summary>
/// Client for retrieving provider information from the Mastercard API.
/// </summary>
public class ProvidersClient : ClientBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProvidersClient"/> class.
    /// </summary>
    /// <param name="restClient">The RestClient instance used for HTTP requests.</param>
    /// <param name="logger">The logger instance for logging errors and information.</param>
    public ProvidersClient(RestClient restClient, IRequestResponseLogger requestResponseLogger, ILogger<ProvidersClient> logger) : base(restClient, requestResponseLogger, logger)
    {
    }

    /// <summary>
    /// Retrieves a list of providers from the API, with optional pagination parameters.
    /// </summary>
    /// <param name="request">The request object containing optional limit and offset for pagination.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{Object, ErrorResponse}"/> containing either the list of providers or an error response.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the request is null.</exception>
    public Task<Either<object, ErrorResponse>> GetProvidersAsync(ProviderRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var restRequest = new RestRequest("providers")
        {
            Method = Method.Get
        };

        if (request.Limet.HasValue)
        {
            restRequest.AddParameter("limit", request.Limet.Value);
        }

        if (request.Offset.HasValue)
        {
            restRequest.AddParameter("offset", request.Offset.Value);
        }

        return ExecuteAsync<object>(restRequest, cancellationToken);
    }
}