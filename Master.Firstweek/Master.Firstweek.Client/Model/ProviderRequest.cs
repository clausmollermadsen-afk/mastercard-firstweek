namespace Master.Firstweek.Client.Model;

public class ProviderRequest : BaseRequest
{
    public required string CountryCode { get; set; }

    public required string PaymentRail { get; set; }
}