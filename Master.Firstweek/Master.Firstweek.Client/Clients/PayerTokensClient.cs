using Master.Firstweek.Client.Model;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Master.Firstweek.Client.Clients;

/// <summary>
/// Client for interacting with the Mastercard API's payer tokens endpoints.
/// Provides methods to create and retrieve payer tokens.
/// </summary>
public class PayerTokensClient : ClientBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PayerTokensClient"/> class.
    /// </summary>
    /// <param name="restClient">The RestClient instance used for HTTP requests.</param>
    /// <param name="logger">The logger instance for logging errors and information.</param>
    public PayerTokensClient(RestClient restClient, IRequestResponseLogger requestResponseLogger, ILogger<PayerTokensClient> logger) : base(restClient, requestResponseLogger, logger)
    {
    }

    /// <summary>
    /// Creates a new payer token by sending a POST request to the API.
    /// </summary>
    /// <param name="request">The request object containing payer token creation details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{Object, ErrorResponse}"/> containing either the created payer token or an error response.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the request is null.</exception>
    public Task<Either<object, ErrorResponse>> CreatePayerTokenAsync(CreatePayerTokenInput request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var restRequest = new RestRequest("payer-tokens")
        {
            Method = Method.Post,
        };
        restRequest.AddJsonBody(request);

        return ExecuteAsync<object>(restRequest, cancellationToken);
    }

    /// <summary>
    /// Retrieves a payer token by its identifier by sending a GET request to the API.
    /// </summary>
    /// <param name="request">The payer token identifier.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{PayerTokenOutput, ErrorResponse}"/> containing either the payer token details or an error response.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the request is null.</exception>
    public Task<Either<PayerTokenOutput, ErrorResponse>> GetPayerTokenAsync(string request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var restRequest = new RestRequest($"payer-tokens/{request}")
        {
            Method = Method.Get,
        };

        return ExecuteAsync<PayerTokenOutput>(restRequest, cancellationToken);
    }
}