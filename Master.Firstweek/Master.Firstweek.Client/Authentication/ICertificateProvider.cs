using System.Security.Cryptography;

namespace Master.Firstweek.Client.Authentication;

/// <summary>
/// Provides an interface for retrieving an RSA private key for signing JWTs in Mastercard authentication.
/// </summary>
public interface ICertificateProvider
{
    /// <summary>
    /// Returns the RSA private key used for signing JWTs.
    /// </summary>
    /// <returns>An RSA instance containing the private key.</returns>
    RSA Key();
}