using Master.Firstweek.Client.Model;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Master.Firstweek.Client.Clients;

/// <summary>
/// Client for handling payment operations with the Mastercard API.
/// Provides methods to create payments for different payment types.
/// </summary>
public class PaymentsClient : ClientBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentsClient"/> class.
    /// </summary>
    /// <param name="restClient">The RestClient instance used for HTTP requests.</param>
    /// <param name="logger">The logger instance for logging errors and information.</param>
    public PaymentsClient(RestClient restClient, IRequestResponseLogger requestResponseLogger, ILogger<PaymentsClient> logger) : base(restClient, requestResponseLogger, logger)
    {
    }
    
    /// <summary>
    /// Creates a new payment using the UK Faster Payments scheme.
    /// </summary>
    /// <param name="request">The request object containing payment details for UK Faster Payments.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{CreateAcceptPaymentOutput, ErrorResponse}"/> containing either the payment result or an error response.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the request is null.</exception>
    public Task<Either<CreateAcceptPaymentOutput, ErrorResponse>> CreatePayment(CreateAcceptPaymentUkFasterPaymentInput request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var restRequest = new RestRequest("payments")
        {
            Method = Method.Post,
        };
        restRequest.AddJsonBody(request);
        
        return ExecuteAsync<CreateAcceptPaymentOutput>(restRequest, cancellationToken);
    }
    
    /// <summary>
    /// Creates a new payment using the Danish Domestic Credit Transfer Instant scheme.
    /// </summary>
    /// <param name="request">The request object containing payment details for Danish Domestic Credit Transfer Instant.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="Either{CreateAcceptPaymentOutput, ErrorResponse}"/> containing either the payment result or an error response.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the request is null.</exception>
    public Task<Either<CreateAcceptPaymentOutput, ErrorResponse>> CreatePayment(CreateAcceptPaymentDanishDomesticCreditTransferInstantInput request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var restRequest = new RestRequest("payments")
        {
            Method = Method.Post, 
        };
        restRequest.AddJsonBody(request);
        
        return ExecuteAsync<CreateAcceptPaymentOutput>(restRequest, cancellationToken);
    }
}