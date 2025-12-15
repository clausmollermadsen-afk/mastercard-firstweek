using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class CreateAcceptPaymentUkFasterPaymentInput
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
        public string DestinationId { get; set; }

        /// <summary>
        /// The URL which the end user is taken to, upon completion of the payment flow.
        /// </summary>
        /// <value>The URL which the end user is taken to, upon completion of the payment flow.</value>
        /* <example>https://httpbin.org/anything</example> */
        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The payment currency. 3 char ISO 4217 currency code. Must be set to &#x60;GBP&#x60;.
        /// </summary>
        /// <value>The payment currency. 3 char ISO 4217 currency code. Must be set to &#x60;GBP&#x60;.</value>
        /* <example>GBP</example> */
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
        /// Unique identifier defined by the sender of the payment.
        /// </summary>
        /// <value>Unique identifier defined by the sender of the payment.</value>
        /* <example>PO-01012024-00010009</example> */
        [JsonPropertyName("endToEndId")]
        public string EndToEndId { get; set; }

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
        /// Gets or Sets Context
        /// </summary>
        [JsonPropertyName("context")]
        public PaymentContextUkFasterPaymentsInput? Context { get; set;  }

        /// <summary>
        /// Pre-select the bank (provider) that will be used for the payment.  When setting this attribute the payment will be locked to the defined provider.  If not set, the payer will be presented with a list of banks to choose from. &lt;a href&#x3D;\&quot;/documentation/scheme?schemeId&#x3D;UkFasterPayments\&quot;&gt;Providers available for chosen Payment Rail.&lt;/a&gt;
        /// </summary>
        /// <value>Pre-select the bank (provider) that will be used for the payment.  When setting this attribute the payment will be locked to the defined provider.  If not set, the payer will be presented with a list of banks to choose from. &lt;a href&#x3D;\&quot;/documentation/scheme?schemeId&#x3D;UkFasterPayments\&quot;&gt;Providers available for chosen Payment Rail.&lt;/a&gt;</value>
        /* <example>GB_TestBank</example> */
        [JsonPropertyName("providerId")]
        public string? ProviderId { get; set; }

        /// <summary>
        /// Whether or not the account the payer uses should be remembered or not. If true, the source account the end user  uses for the payment will be captured and displayed in the (Mastercard managed) payment success screen. It might be  relevant to inform the end user that their account will be stored.  If used in conjunction with pre-selecting the source account using an existing Remember Payer Token the existing  Remember Payer Token&#39;s expiry date will be extended.
        /// </summary>
        /// <value>Whether or not the account the payer uses should be remembered or not. If true, the source account the end user  uses for the payment will be captured and displayed in the (Mastercard managed) payment success screen. It might be  relevant to inform the end user that their account will be stored.  If used in conjunction with pre-selecting the source account using an existing Remember Payer Token the existing  Remember Payer Token&#39;s expiry date will be extended.</value>
        /* <example>true</example> */
        [JsonPropertyName("rememberPayer")]
        public bool? RememberPayer { get; set; }

        /// <summary>
        /// Gets or Sets PreselectedSource
        /// </summary>
        [JsonPropertyName("preselectedSource")]
        public PreselectedBbanSourceAccountInput? PreselectedSource { get; set; }

        /// <summary>
        /// Gets or Sets EndUser
        /// </summary>
        [JsonPropertyName("endUser")]
        public UkFasterPaymentsEndUser? EndUser { get; set; }
}