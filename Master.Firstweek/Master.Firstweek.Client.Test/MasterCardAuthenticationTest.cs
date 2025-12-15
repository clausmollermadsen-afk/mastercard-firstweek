using System.Net.Http.Headers;
using System.Text.Json;
using Master.Firstweek.Client.Authentication;
using Master.Firstweek.Client.Model;
using Master.Firstweek.Client.Test.Data;
using RestSharp;

namespace Master.Firstweek.Client.Test;

/// <summary>
/// Unit tests for Mastercard OAuth 2.0 authentication.
/// </summary>
public class MasterCardAuthenticationTest
{
    private readonly MasterCardAuthenticator _authenticator;

    /// <summary>
    /// Initializes shared test configuration and authenticator for all tests.
    /// </summary>
    public MasterCardAuthenticationTest()
    {
        var certificateProvider = new CertificateProvider();
        _authenticator = new MasterCardAuthenticator(TestData.ClientConfiguration, certificateProvider);
    }

    /// <summary>
    /// Tests that the Mastercard OAuth 2.0 authenticator returns a valid token.
    /// </summary>
    [Fact]
    public async Task GetToken_ReturnsValidToken()
    {
        // Act: request token
        var result = await _authenticator.GetToken();

        // Assert: token should not be null or empty and should start with "Bearer "
        Assert.False(string.IsNullOrWhiteSpace(result));
        Assert.StartsWith("Bearer ", result, StringComparison.OrdinalIgnoreCase);
        
        string token = result.Replace("Bearer ", string.Empty);
    }

    [Fact]
    public async Task DoRestCall()
    {
        RestClient client = new RestClient(
            new RestClientOptions()
            {
                BaseUrl = new Uri("https://aiiastorage-payments.test.aiia.eu"),
                Authenticator = _authenticator 
            });

        var restRequest = new RestRequest("providers");
        var result = await client.GetAsync(restRequest);   
    }
    
    
    [Fact]
    public async Task DoRestCallWithHttp()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://aiiastorage-payments.test.aiia.eu");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", (await _authenticator.GetToken()).Replace("Bearer ", ""));
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync("providers");
    }
    
    
    [Fact]
    public async Task DoRestCallWithHttpPayerTokens()
    {
        
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://aiiastorage-payments.test.aiia.eu");


        var t = (await _authenticator.GetToken()).Replace("Bearer ", "");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", (await _authenticator.GetToken()).Replace("Bearer ", ""));
        
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        
        HttpContent content = new StringContent(JsonSerializer.Serialize(new CreatePayerTokenInput
        {
            PaymentId = Guid.NewGuid().ToString(),
        }), System.Text.Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("payer-tokens", content );

        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}