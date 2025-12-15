using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class DanishDomesticCreditTransferInstantEndUser
{        /// <summary>
        /// End user identifier assigned by the client. This field is required when the tenant is unlicensed.
        /// </summary>
        /// <value>End user identifier assigned by the client. This field is required when the tenant is unlicensed.</value>
        /* <example>0001789937234</example> */
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Full name of the end user.
        /// </summary>
        /// <value>Full name of the end user.</value>
        /* <example>Jane Doe</example> */
        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        /// <summary>
        /// Email address of the end user.
        /// </summary>
        /// <value>Email address of the end user.</value>
        /* <example>jane.doe@example.com</example> */
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Phone number of the end user.
        /// </summary>
        /// <value>Phone number of the end user.</value>
        /* <example>+441234567890</example> */
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Date of birth of the end user.
        /// </summary>
        /// <value>Date of birth of the end user.</value>
        /* <example>Mon Jan 01 00:00:00 UTC 1990</example> */
        [JsonPropertyName("dateOfBirth")]
        public DateOnly? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [JsonPropertyName("address")]
        public DanishDomesticCreditTransferInstantPaymentAddressInput? Address { get; set; }

}