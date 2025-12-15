using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Authentication;

/// <summary>
/// TokenResponse is a record type for deserializing the OAuth 2.0 token response JSON.
/// </summary>
public record TokenResponse {
    /// <summary>
    /// The type of token issued (typically "Bearer").
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; } = string.Empty;

    /// <summary>
    /// The access token string to be used in API requests.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = string.Empty;
}