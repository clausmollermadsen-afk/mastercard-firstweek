using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Authentication;

/// <summary>
/// TokenRequest is a record type for serializing the OAuth 2.0 client credentials request body.
/// </summary>
public record TokenRequest
{
    /// <summary>
    /// The OAuth 2.0 grant type, typically "client_credentials" for this flow.
    /// </summary>
    [JsonPropertyName("grant_type")]
    public required string GrantType { get; init; }

    /// <summary>
    /// The type of client assertion, always "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" for JWT assertion.
    /// </summary>
    [JsonPropertyName("client_assertion_type")]
    public required string ClientAssertionType { get; init; }

    /// <summary>
    /// The JWT signed with your private key, used for client authentication.
    /// </summary>
    [JsonPropertyName("client_assertion")]
    public required string ClientAssertion { get; init; }

    /// <summary>
    /// The requested OAuth scope, e.g. "ob_accept_payments".
    /// </summary>
    [JsonPropertyName("scope")]
    public required string[] Scope { get; init; }
}