using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class CreateAcceptPaymentDanishDomesticCreditTransferInstantInput
{
    /// <summary>
        /// The payment rail by which the payment will be executed. * &#x60;UkFasterPayments&#x60; * &#x60;SwedishPlusGiroTransfer&#x60; * &#x60;SwedishDomesticCreditTransferLegacy&#x60; * &#x60;SwedishBankGiroTransfer&#x60; * &#x60;SepaCreditTransferLegacy&#x60; * &#x60;SepaCreditTransferInstantLegacy&#x60; * &#x60;SepaCreditTransfer&#x60; * &#x60;PolishDomesticSorbnet&#x60; * &#x60;PolishDomesticExpressElixir&#x60; * &#x60;PolishDomesticElixir&#x60; * &#x60;PolishDomesticCreditTransfer&#x60; * &#x60;NorwegianDomesticCreditTransferKid&#x60; * &#x60;NorwegianDomesticCreditTransfer&#x60; * &#x60;GermanSepaCreditTransferInstant&#x60; * &#x60;GermanSepaCreditTransfer&#x60; * &#x60;FrenchSepaCreditTransfer&#x60; * &#x60;FinnishDomesticCreditTransferViite&#x60; * &#x60;FinnishDomesticCreditTransfer&#x60; * &#x60;EstonianDomesticCreditTransferViite&#x60; * &#x60;DanishDomesticCreditTransferInstant&#x60; * &#x60;DanishDomesticCreditTransferGiro04&#x60; * &#x60;DanishDomesticCreditTransferFI71&#x60; * &#x60;DanishDomesticCreditTransfer&#x60; * &#x60;AustrianSepaCreditTransfer&#x60; 
        /// </summary>
        /// <value>The payment rail by which the payment will be executed. * &#x60;UkFasterPayments&#x60; * &#x60;SwedishPlusGiroTransfer&#x60; * &#x60;SwedishDomesticCreditTransferLegacy&#x60; * &#x60;SwedishBankGiroTransfer&#x60; * &#x60;SepaCreditTransferLegacy&#x60; * &#x60;SepaCreditTransferInstantLegacy&#x60; * &#x60;SepaCreditTransfer&#x60; * &#x60;PolishDomesticSorbnet&#x60; * &#x60;PolishDomesticExpressElixir&#x60; * &#x60;PolishDomesticElixir&#x60; * &#x60;PolishDomesticCreditTransfer&#x60; * &#x60;NorwegianDomesticCreditTransferKid&#x60; * &#x60;NorwegianDomesticCreditTransfer&#x60; * &#x60;GermanSepaCreditTransferInstant&#x60; * &#x60;GermanSepaCreditTransfer&#x60; * &#x60;FrenchSepaCreditTransfer&#x60; * &#x60;FinnishDomesticCreditTransferViite&#x60; * &#x60;FinnishDomesticCreditTransfer&#x60; * &#x60;EstonianDomesticCreditTransferViite&#x60; * &#x60;DanishDomesticCreditTransferInstant&#x60; * &#x60;DanishDomesticCreditTransferGiro04&#x60; * &#x60;DanishDomesticCreditTransferFI71&#x60; * &#x60;DanishDomesticCreditTransfer&#x60; * &#x60;AustrianSepaCreditTransfer&#x60; </value>
        /* <example>UkFasterPayments</example> */
        [JsonPropertyName("paymentRail")]
        public string PaymentRail { get; set; }

        /// <summary>
        /// The ID of the destination that will receive the payment.
        /// </summary>
        /// <value>The ID of the destination that will receive the payment.</value>
        /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
        [JsonPropertyName("destinationId")]
        public Guid DestinationId { get; set; }

        /// <summary>
        /// The URL which the end user is taken to, upon completion of the payment flow.
        /// </summary>
        /// <value>The URL which the end user is taken to, upon completion of the payment flow.</value>
        /* <example>https://httpbin.org/anything</example> */
        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The payment currency. 3 char ISO 4217 currency code. Must be set to &#x60;DKK&#x60;.
        /// </summary>
        /// <value>The payment currency. 3 char ISO 4217 currency code. Must be set to &#x60;DKK&#x60;.</value>
        /* <example>DKK</example> */
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The payment amount in the specified currency.
        /// </summary>
        /// <value>The payment amount in the specified currency.</value>
        /* <example>123.5</example> */
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Reference assigned to the payment by the client.  Allows the client to control an identifier that will not get sent  to the providers, for easier reconciliation or other purposes.
        /// </summary>
        /// <value>Reference assigned to the payment by the client.  Allows the client to control an identifier that will not get sent  to the providers, for easier reconciliation or other purposes.</value>
        /* <example>Example client assigned reference</example> */
        [JsonPropertyName("clientAssignedReference")]
        public string? ClientAssignedReference { get; set; }

        /// <summary>
        /// The display language of the flow.  ISO 639-1 language code, optionally followed by a dash and a ISO 3166 country code.  Will be applied to UI. Defaults to browser&#39;s culture.
        /// </summary>
        /// <value>The display language of the flow.  ISO 639-1 language code, optionally followed by a dash and a ISO 3166 country code.  Will be applied to UI. Defaults to browser&#39;s culture.</value>
        /* <example>en-US</example> */
        [JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// The ID of the theme to use for the payment flow.
        /// </summary>
        /// <value>The ID of the theme to use for the payment flow.</value>
        /* <example>ThemeId</example> */
        [JsonPropertyName("themeId")]
        public string? ThemeId { get; set; }

        /// <summary>
        /// Message to the receiver of the payment.
        /// </summary>
        /// <value>Message to the receiver of the payment.</value>
        /* <example>Example Reference</example> */
        [JsonPropertyName("reference")]
        public string? Reference { get; set; }

        /// <summary>
        /// Message to the payer of the payment.
        /// </summary>
        /// <value>Message to the payer of the payment.</value>
        /* <example>Example Identifier</example> */
        [JsonPropertyName("messageToPayer")]
        public string? MessageToPayer { get; set; }

        /// <summary>
        /// Unique identifier defined by the sender of the payment. Available when not using Mastercard Settlement Accounts.
        /// </summary>
        /// <value>Unique identifier defined by the sender of the payment. Available when not using Mastercard Settlement Accounts.</value>
        /* <example>PO-01012024-00010009</example> */
        [JsonPropertyName("endToEndId")]
        public string? EndToEndId { set; get; }

        /// <summary>
        /// Pre-select the bank (provider) that will be used for the payment.  When setting this attribute the payment will be locked to the defined provider.  If not set, the payer will be presented with a list of banks to choose from. &lt;a href&#x3D;\&quot;/documentation/scheme?schemeId&#x3D;DanishDomesticCreditTransferInstant\&quot;&gt;Providers available for chosen Payment Rail.&lt;/a&gt;
        /// </summary>
        /// <value>Pre-select the bank (provider) that will be used for the payment.  When setting this attribute the payment will be locked to the defined provider.  If not set, the payer will be presented with a list of banks to choose from. &lt;a href&#x3D;\&quot;/documentation/scheme?schemeId&#x3D;DanishDomesticCreditTransferInstant\&quot;&gt;Providers available for chosen Payment Rail.&lt;/a&gt;</value>
        /* <example>DK_AiiaTestBank</example> */
        [JsonPropertyName("providerId")]
        public string? ProviderId { get; set; }

        /// <summary>
        /// Gets or Sets EndUser
        /// </summary>
        [JsonPropertyName("endUser")]
        public DanishDomesticCreditTransferInstantEndUser? EndUser { get; set; }

}