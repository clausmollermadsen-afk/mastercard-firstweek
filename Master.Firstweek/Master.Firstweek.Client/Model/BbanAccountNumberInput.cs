using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class BbanAccountNumberInput
{
    /// <summary>
    /// Number assigned to a branch of a bank, commonly used in UK
    /// </summary>
    /// <value>Number assigned to a branch of a bank, commonly used in UK</value>
    [JsonPropertyName("sortCode")]
    public string SortCode { get; set; }

    /// <summary>
    /// The account number
    /// </summary>
    /// <value>The account number</value>
    [JsonPropertyName("accountNumber")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// The legal name of the holder of the account. Can be a physical person or a business
    /// </summary>
    /// <value>The legal name of the holder of the account. Can be a physical person or a business</value>
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }
}