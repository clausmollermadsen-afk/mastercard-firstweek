using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using RestSharp.Authenticators;

namespace Master.Firstweek.Client.Authentication;

/// <summary>
/// Authenticator for Mastercard OAuth 2.0 using JWT client assertion.
/// </summary>
public class MasterCardAuthenticator(ClientConfiguration configuration, ICertificateProvider certificateProvider) : AuthenticatorBase("")
{
    /// <summary>
    /// Stores the current access token.
    /// </summary>
    private string? _token;

    /// <summary>
    /// Adds the Authorization header with the Bearer token to outgoing requests.
    /// </summary>
    /// <param name="accessToken">Unused parameter, required by base class.</param>
    /// <returns>HeaderParameter with Authorization header.</returns>
    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        _token = string.IsNullOrEmpty(_token) ? await GetToken() : _token;
        return new HeaderParameter(KnownHeaders.Authorization, _token);
    }
    
    /// <summary>
    /// Requests an OAuth 2.0 access token from Mastercard using JWT client assertion.
    /// </summary>
    /// <returns>Access token string in the format "Bearer {access_token}".</returns>
    public async Task<string> GetToken() {
        var token = new JwtSecurityToken(
            claims: [new System.Security.Claims.Claim("sub", configuration.ConsumerKey)],
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(60),
            signingCredentials: new SigningCredentials(new RsaSecurityKey(certificateProvider.Key()), SecurityAlgorithms.RsaSha256)
        );
        
        token.Header.Add("kid", Guid.NewGuid().ToString());
        //token.Payload.Add("jti", Guid.NewGuid().ToString());
        var clientAssertion = new JwtSecurityTokenHandler().WriteToken(token);

        var tokenRequest = new TokenRequest()
        {
            ClientAssertion = clientAssertion,
            ClientAssertionType = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
            GrantType = "client_credentials",
            Scope = ["ob_accept_payments", "ob_onboarding", "ob_theming", "ob_reporting", "ob_data", "ob_providers"]
            //Scope = ["ob_accept_payments", "ob_onboarding", "ob_theming", "ob_reporting"]
        };
        
        // ob_accept_payments, ob_onboarding, ob_theming, ob_reporting, ob_data, ob_providers
        // ob_data and ob_providers currently does not work, gives 400 Bad Request with "invalid_scope" error.

        var request = new RestRequest("oauth2/token")
            .AddJsonBody(JsonSerializer.Serialize(tokenRequest));
        
        using var client = new RestClient(configuration.BaseUrlAuth);
        
        var response = await client.PostAsync<TokenResponse>(request);
        if (response is null)
            throw new InvalidOperationException("Token response was null.");
        return $"Bearer {response.AccessToken}";
    }
}