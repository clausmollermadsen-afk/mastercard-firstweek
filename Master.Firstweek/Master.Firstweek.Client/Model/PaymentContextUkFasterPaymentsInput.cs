using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PaymentContextUkFasterPaymentsInput
{

    /// <summary>
    /// Specifies the payment context.
    /// </summary>
    /// <value>Specifies the payment context.</value>
    /* <example>BillingGoodsAndServicesInAdvance</example> */
    [JsonPropertyName("contextCode")]
    public string? ContextCode { get; set; }

    /// <summary>
    /// Specific purpose within the context.  E.g. Specific type of goods for a E-commerce context payment.
    /// </summary>
    /// <value>Specific purpose within the context.  E.g. Specific type of goods for a E-commerce context payment.</value>
    /* <example>GDSV</example> */
    [JsonPropertyName("purposeCode")]
    public string? PurposeCode { get; set; }

    /// <summary>
    /// Gets or Sets DeliveryAddress
    /// </summary>
    [JsonPropertyName("deliveryAddress")]
    public UkFasterPaymentsPaymentAddressInput? DeliveryAddress { get; set; }
}