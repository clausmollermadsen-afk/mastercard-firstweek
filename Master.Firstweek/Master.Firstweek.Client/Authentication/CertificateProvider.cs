using System.Security.Cryptography;

namespace Master.Firstweek.Client.Authentication;

/// <summary>
/// Provides the RSA private key for Mastercard OAuth 2.0 JWT signing.
/// </summary>
public class CertificateProvider : ICertificateProvider
{
    /// <summary>
    /// Loads and returns the RSA private key from a PEM-encoded string.
    /// </summary>
    /// <returns>An RSA instance containing the private key.</returns>
    public RSA Key()
    {
        // PEM-encoded RSA private key used for signing JWTs.
        string privateKey = 
            @"-----BEGIN PRIVATE KEY-----
MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDAJLMDdtrKcU+D
d3yuWyPfj+rvGvhpoltDKLPiRM36sf6Jr84TQpCNIrvG1sC88leVHL1/NlsMk18e
9RYNv8ilswcNBBxD5kc1LSEogxi0RvTpf8AMiIdPDXUwDfH+wqPqb4uq/8c8DYyH
DHNxNoeKaK50RL8F8cEf+KQLWcYxebN9qQxKmTZVZdWNEKL/0nJnDu19CCp76AGK
h3WcJHncWVX+GfBuLfT/uXH1/wwUKPlycE6pjx93kD5b5vYu9UuWQncXtU9mKRMs
fjJXkd2xxXz7U8D+NYJo0HAD3lb6SG3mpXQYKIRVBHjwnKujWpdW2sIkiUuX/AGC
F025fvCXAgMBAAECggEACnaZuiSRXP1uFaCsaKEeg0VGx1TWqIevtt+ujlZk22rn
sCPIKMvFK/gX9axPBXsOHes0voq0FFAX4tSLBXnL3ffWHQegjvxN29IJCaW8PBdE
iLqj7mY47KsiqI+MIlsnqoqREfOo9Ptf5tdcvElDnW41WLAbaA+/oNymQkSM+ZLx
+XSHmst3RHN/Dwl0dtYokpUht6VToMfhAAJpyyXkgML+KhYzhsF0SqsWwXRStjc2
fCoWYTe7hP5zU0LwOQ33he4KT3YiA7VBlUdJ1XHM5VYRLBTNAdC8RL6KFok88o+V
dyfj3Xk7XkPXgZciM8AsyDnw8jurObL50+5mib+YEQKBgQDtcPHBDqVzjSvw1szH
Z9NWApedfywwJnK6qqhWxrsC8k+wmF/X/XAvU7cCTY0aQDTmcFgGpIHl70zSP7sT
OE8R9J18u8hrrUePlIX/iRbYbqwMjh85BxKhsfQAuzIddu0KA3Q0tctTb4B5UhZN
lhIGUAJhupcFIbd8DTmDW79bBQKBgQDPKV9bWbx7Z6QcpRg4IIymKqFtnL3h1bqq
1d8IN+lq9bcBm5oXBOOXgkkfdsp4Vl3w3hshzk1XR5BGdhqgQOigr7wzqDyMnELV
P1Qj3/Kk/6n+Qpk5y4/3IcPnfY57mkXjqQNT3PeJwcSYCdnbf5N/hBPpaKbvMxzG
YVwGZ7hH6wKBgBvrPeHvcPDnVpVZDHcd9DGW2HECdRWsT603R9f8Qh0UlN407IAf
IsPN2iUBLWg6yH2YFCGj0kpRGv1V1Q9rfZCk7KewBN70Xwe49RCY9AC68qv/QhiY
hk5Q+FnlqPzh8PlOcqmH/sJux/J7/ndc//2SBtWq9Pr7ffGuNGcHsLZpAoGAXETr
Kf7wCm8BE5kdDnLA8onuWKoFkP7nI4wayMhOeMt0dYzetv4AeM0Y0KDSUYL2WIA0
yXvfys4fHqMf/NysQFXFl6SJQ3+d7OlGCqyGoKMXDh6PrMRUHRi27vZnbfoqwtnW
l5XF01+wtp88n51VDui/DakFIWk8mcdne5ra430CgYEApQMLz0QC4Bc25A6v/Hd2
sQie1MqzD/0gsdW4Jt0EWbLKUBKunSIE2egNLsFW10QlphtwGiwh2ap6KrDlr/ci
VUlgJjucnaX+3GBr/0jSPyh35W2KSxRwl80X3Abw5dImjhE4bipZzBxD28YTHfoM
y3kHHUnJsPBjWjghrGtY9sM=
-----END PRIVATE KEY-----";

        // Create an RSA object and import the PEM key.
        RSA rsa = RSA.Create();
        rsa.ImportFromPem(privateKey.ToCharArray());
        return rsa;
    }
}