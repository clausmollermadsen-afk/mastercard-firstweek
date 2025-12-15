using Microsoft.Extensions.DependencyInjection;
using Master.Firstweek.Client.Authentication;
using Master.Firstweek.Client.Clients;
using RestSharp;

namespace Master.Firstweek.Client
{
    /// <summary>
    /// Extension methods for registering Client project dependencies.
    /// </summary>
    public static class ClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all services from the Client project.
        /// </summary>
        /// <param name="services">The service collection to add dependencies to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            // Register authentication and certificate providers
            services.AddSingleton<ICertificateProvider, CertificateProvider>();
            services.AddScoped<MasterCardAuthenticator>();
            services.AddSingleton(
                    new ClientConfiguration(
                        "https://authentication-service.test.aiia.eu",
                        "https://aiiastorage-payments.test.aiia.eu",
                        "50d7777f-cbbc-4c49-9afe-d7fae0c17126")
            );

            // Register API clients
            services.AddScoped<ProvidersClient>();
            services.AddScoped<PayerTokensClient>();
            services.AddScoped<PaymentsClient>();
            services.AddScoped<RestClient>(serviceProvider =>
            {
                var authenticator = serviceProvider.GetRequiredService<MasterCardAuthenticator>();
                var clientConfig = serviceProvider.GetRequiredService<ClientConfiguration>();

                return new RestClient(
                    new RestClientOptions()
                    {
                        BaseUrl = new Uri(clientConfig.BaseUrlApi),
                        Authenticator = authenticator
                    });
            });
            return services;
        }
    }
}
