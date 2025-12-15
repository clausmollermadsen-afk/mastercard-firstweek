namespace Master.Firstweek.Client;

/// <summary>
/// Represents the configuration required for Mastercard API client authentication and API calls.
/// </summary>
/// <param name="BaseUrlAuth">The base URL for Mastercard authentication endpoints.</param>
/// <param name="BaseUrlApi">The base URL for Mastercard API endpoints.</param>
/// <param name="ConsumerKey">The consumer key assigned to your application by Mastercard.</param>
public record ClientConfiguration(string BaseUrlAuth, string BaseUrlApi, string ConsumerKey);
