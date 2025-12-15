using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PreselectedBbanSourceAccountInput
{        /// <summary>
    /// Id of the Remember Payer Token.
    /// </summary>
    /// <value>Id of the Remember Payer Token.</value>
    /* <example>0e01fe45-8a06-4158-b12b-92e321addbd0</example> */
    [JsonPropertyName("payerTokenId")]
    public Guid? PayerTokenId { get; set; }

    /// <summary>
    /// Describes how to proceed with unclear preselected source mapping
    /// </summary>
    /// <value>Describes how to proceed with unclear preselected source mapping</value>
    [JsonPropertyName("allowAccountChange")]
    public bool? AllowAccountChange { get; set; }

    /// <summary>
    /// Gets or Sets AccountNumber
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public BbanAccountNumberInput? AccountNumber { get; set; }
}