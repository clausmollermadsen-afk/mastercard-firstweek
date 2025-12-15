using System.Text.Json;
using Master.Firstweek.Client;
using Master.Firstweek.Client.Model;
using Master.Firstweek.WebApp.Data;

namespace Master.Firstweek.WebApp.Service;


public class RequestResponseLogger : IRequestResponseLogger
{
    private readonly ApplicationDbContext _context;

    public RequestResponseLogger(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task LogRequestResonseAsync<TRequest, TResponse>(TRequest request, TResponse response, ErrorResponse? errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        await _context.RequestResponseLogs.AddAsync(new RequestResponseLog() 
            {
                Request = JsonSerializer.Serialize(request),
                Error =  JsonSerializer.Serialize(errorResponse),
                }, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task LogRequestResonseAsync<TRequest>(TRequest request, ErrorResponse errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class
    {
        await _context.RequestResponseLogs.AddAsync(new RequestResponseLog() 
        {
            Request = JsonSerializer.Serialize(request),
            Error =  JsonSerializer.Serialize(errorResponse),
        }, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}