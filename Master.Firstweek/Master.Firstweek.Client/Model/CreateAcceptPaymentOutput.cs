using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class CreateAcceptPaymentOutput
{
    /// <summary>
    /// URL of the authorization app, which the user is taken to.  Set if an SCA is required for the payment
    /// </summary>
    /// <value>URL of the authorization app, which the user is taken to.  Set if an SCA is required for the payment</value>
    /* <example>https://connect.aiia.eu/start/storage-uk-payments/e894a238-4738-4b2a-8ccd-30426552f0d8&quot;</example> */
    [JsonPropertyName("flowUrl")]
    public string FlowUrl { get; set; }

    /// <summary>
    /// ID of the payment.
    /// </summary>
    /// <value>ID of the payment.</value>
    /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
    [JsonPropertyName("paymentId")]
    public Guid PaymentId { get; set; }
    
}