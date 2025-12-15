using Master.Firstweek.Client.Model;

namespace Master.Firstweek.Client;

public interface IRequestResponseLogger
{
    public Task LogRequestResonseAsync<TRequest, TResponse>(TRequest request, TResponse response,
        ErrorResponse? errorResponse, CancellationToken cancellationToken = default)
        where TRequest : class
        where TResponse : class;


    public Task LogRequestResonseAsync<TRequest>(TRequest request,
        ErrorResponse errorResponse, CancellationToken cancellationToken = default)
        where TRequest : class;
}