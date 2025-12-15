using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PayerTokenOutput : BaseRequest
{
        /// <summary>
        /// Id of the Remember Payer Token.
        /// </summary>
        /// <value>Id of the Remember Payer Token.</value>
        /* <example>0e01fe45-8a06-4158-b12b-92e321addbd0</example> */
        [JsonPropertyName("payerTokenId")]
        public required string PayerTokenId { get; set; }

        /// <summary>
        /// The payment rail by which the payment will be executed.
        /// </summary>
        /// <value>The payment rail by which the payment will be executed.</value>
        /* <example>UkFasterPayments</example> */
        [JsonPropertyName("paymentRail")]
        public required string PaymentRail { get; set; }

        /// <summary>
        /// The provider of the source account.
        /// </summary>
        /// <value>The provider of the source account.</value>
        /* <example>GB_TestBank</example> */
        [JsonPropertyName("providerId")]
        public required string ProviderId { get; set; }

        /// <summary>
        /// The date and time the payer token will expire at.  This reflects the regulation for how long Mastercard is allowed to keep the source account information for a  payment.  The expiration date can be extended if the payer token is used for a successful payment while having the  rememberPayer option enabled.
        /// </summary>
        /// <value>The date and time the payer token will expire at.  This reflects the regulation for how long Mastercard is allowed to keep the source account information for a  payment.  The expiration date can be extended if the payer token is used for a successful payment while having the  rememberPayer option enabled.</value>
        /* <example>2024-01-17T12:29:36.919957Z</example> */
        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// The ID of the destination that will receive the payment. If provided, it means that the Payer Token can only be  used for making payments to a single destination.
        /// </summary>
        /// <value>The ID of the destination that will receive the payment. If provided, it means that the Payer Token can only be  used for making payments to a single destination.</value>
        /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
        [JsonPropertyName("destinationId")]
        public Guid DestinationId { get; set; }

        /// <summary>
        /// The account number in a display friendly format. Examples:
        /// </summary>
        /// <value>The account number in a display friendly format. Examples:</value>
        /* <example>DK************6789</example> */
        [JsonPropertyName("displayAccountNumber")]
        public string? DisplayAccountNumber { get; set; }
}