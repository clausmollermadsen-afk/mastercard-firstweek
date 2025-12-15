using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class DanishDomesticCreditTransferInstantPaymentAddressInput
{

    /// <summary>
    /// The address specified in free text lines.
    /// </summary>
    /// <value>The address specified in free text lines.</value>
    [JsonPropertyName("addressLines")]
    public List<string>? AddressLines { get; set; }

    /// <summary>
    /// The name of the street.
    /// </summary>
    /// <value>The name of the street.</value>
    /* <example>Street Name</example> */
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// The building number.
    /// </summary>
    /// <value>The building number.</value>
    /* <example>42</example> */
    [JsonPropertyName("buildingNumber")]
    public string? BuildingNumber { get; set; }

    /// <summary>
    /// The Postal Code.
    /// </summary>
    /// <value>The Postal Code.</value>
    /* <example>1234</example> */
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    /// <value>Name of the city.</value>
    /* <example>London</example> */
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The Country Subdivision, i.e. State or County.
    /// </summary>
    /// <value>The Country Subdivision, i.e. State or County.</value>
    /* <example>Greater London</example> */
    [JsonPropertyName("countrySubDivision")]
    public string? CountrySubDivision { get; set; }

    /// <summary>
    /// ISO Country Code.
    /// </summary>
    /// <value>ISO Country Code.</value>
    /* <example>GB</example> */
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}