using Master.Firstweek.Client.Authentication;
using Master.Firstweek.Client.Clients;
using Master.Firstweek.Client.Model;
using Master.Firstweek.Client.Test.Data;
using Microsoft.Extensions.Logging.Abstractions;
using RestSharp;

namespace Master.Firstweek.Client.Test;

public class ClientTest 
{
    private readonly RestClient _restClient;

    public ClientTest()
    {
        var certificateProvider = new CertificateProvider();
        var authenticator = new MasterCardAuthenticator(TestData.ClientConfiguration, certificateProvider);

        _restClient = new RestClient(
            new RestClientOptions()
            {
                BaseUrl = new Uri(TestData.ClientConfiguration.BaseUrlApi),
                Authenticator = authenticator
            });
    }
    
    [Fact]
    public async Task Test_GetProvidersAsync()
    {
        ProvidersClient client = new ProvidersClient(_restClient, new TestRequestResponseLogger(), new NullLogger<ProvidersClient>());
        var response = await client.GetProvidersAsync(new ProviderRequest
        {
            Limet = 10,
            Offset = 0,
            CountryCode = "GB",
            PaymentRail = "UkFasterPayments"
        });   
    }


    [Fact]
    public async Task Test_CreatePayerTokenAsync()
    {
        PayerTokensClient client = new PayerTokensClient(_restClient, new TestRequestResponseLogger(), new NullLogger<PayerTokensClient>());
        var response = await client.CreatePayerTokenAsync(new CreatePayerTokenInput
        {
            PaymentId = Guid.NewGuid().ToString(),
        });
    }
    
    [Fact]
    public async Task Test_GetPayerTokenAsync()
    {
        PayerTokensClient client = new PayerTokensClient(_restClient, new TestRequestResponseLogger(), new NullLogger<PayerTokensClient>());
        var response = await client.GetPayerTokenAsync(Guid.NewGuid().ToString());
    }
    
    
    [Fact]
    public async Task Test_CreatePayment()
    {
        
        
        /*
         * 
           {
           "paymentRail": "UkFasterPayments",
           "destinationId": "472e651e-5a1e-424d-8098-23858bf03ad7",
           "redirectUrl": "https://httpbin.org/anything",
           "clientAssignedReference": "Example client assigned reference",
           "language": "en-US",
           "themeId": "ThemeId",
           "currency": "GBP",
           "reference": "Example Reference",
           "amount": 123.5,
           "context": {
           "contextCode": "BillingGoodsAndServicesInAdvance",
           "purposeCode": "GDSV",
           "deliveryAddress": {}
           },
           "providerId": "GB_TestBank",
           "rememberPayer": true,
           "endToEndId": "PO-01012024-00010009",
           "preselectedSource": {
           "payerTokenId": "0e01fe45-8a06-4158-b12b-92e321addbd0",
           "allowAccountChange": true,
           "accountNumber": {}
           },
           "endUser": {
           "id": "0001789937234",
           "fullName": "Jane Doe",
           "email": "jane.doe@example.com",
           "phone": "+441234567890",
           "dateOfBirth": "1990-01-01",
           "address": {}
           }
         */
        PaymentsClient client = new PaymentsClient(_restClient, new TestRequestResponseLogger(), new NullLogger<PaymentsClient>());
        
        var response = await client.CreatePayment(new CreateAcceptPaymentUkFasterPaymentInput
        {
            PaymentRail =  "UkFasterPayments",
            DestinationId = Guid.NewGuid().ToString(),
            RedirectUrl = "https://httpbin.org/anything",
            ClientAssignedReference = "Example client assigned reference",
            Language = "en-US",
            ThemeId = "ThemeId",
            Currency = "GBP",
            Reference = "Example Reference",
            Amount = 123.5,
            Context = new PaymentContextUkFasterPaymentsInput
            {
                ContextCode = "BillingGoodsAndServicesInAdvance",
                PurposeCode = "GDSV",
                DeliveryAddress = new UkFasterPaymentsPaymentAddressInput()
            },
            ProviderId = "GB_TestBank",
            RememberPayer = false,
            EndToEndId = "PO-01012024-00010009",
            EndUser = new UkFasterPaymentsEndUser
            {
                Id = "0001789937234",
                FullName = "Jane Doe",
                Email = "jane.doe@example.com",
                Phone = "+441234567890",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Address = new UkFasterPaymentsPaymentAddressInput()
                {
                    AddressLines = new List<string>() { "123 Main St" },
                }
            },
        }, cancellationToken: default);
    }
    
    

    [Fact]
    public async Task Test_CreatePayment_Danish()
    {
        
        
        /*
         * 
           "paymentRail": "DanishDomesticCreditTransferInstant",
           "destinationId": "472e651e-5a1e-424d-8098-23858bf03ad7",
           "redirectUrl": "https://httpbin.org/anything",
           "clientAssignedReference": "Example client assigned reference",
           "language": "en-US",
           "themeId": "ThemeId",
           "currency": "DKK",
           "reference": "Example Reference",
           "amount": 123.5,
           "messageToPayer": "Example Identifier",
           "endToEndId": "PO-01012024-00010009",
           "providerId": "DK_AiiaTestBank",
           "endUser": {
           "id": "0001789937234",
           "fullName": "Jane Doe",
           "email": "jane.doe@example.com",
           "phone": "+441234567890",
           "dateOfBirth": "1990-01-01",
           "address": {
           "addressLines": [],
           "street": "Street Name",
           "buildingNumber": "42",
           "postalCode": "1234",
           "city": "London",
           "countrySubDivision": "Greater London",
           "country": "GB"
           }
           }
         */
        PaymentsClient client = new PaymentsClient(_restClient, new TestRequestResponseLogger(), new NullLogger<PaymentsClient>());
        
        var response = await client.CreatePayment(new CreateAcceptPaymentDanishDomesticCreditTransferInstantInput()
        {
            PaymentRail = "DanishDomesticCreditTransferInstant",
            //DestinationId = Guid.Parse("6c4b1a4b-7fb5-4bb9-9243-d1cd374951c5"),
            DestinationId = Guid.Parse("54cf43f6-e9e0-4c87-a278-2212e1dd08d2"),
            // 74bddb98-7024-4e61-9733-79357d445869
            RedirectUrl = "https://httpbin.org/anything",
            ClientAssignedReference = "Example client assigned reference",
            Language =  "en-US",
            ThemeId =  "ThemeId",
            Currency = "DKK",
            Reference = "Example Reference",
            Amount = 123.5,
            MessageToPayer =  "Example Identifier",
            EndUser = new DanishDomesticCreditTransferInstantEndUser 
            {
                Id = "0001789937234",
                FullName = "Jane Doe",
                Email = "jane@doe.dk",
                Phone = "+441234567890",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Address = new DanishDomesticCreditTransferInstantPaymentAddressInput
                {   
                    AddressLines = new List<string>() { "123 Main St" },
                },
            },
            }, cancellationToken: default);
        
        Console.WriteLine(response);
    }
}