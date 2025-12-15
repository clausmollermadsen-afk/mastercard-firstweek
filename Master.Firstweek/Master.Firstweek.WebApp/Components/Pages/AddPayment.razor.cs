using Master.Firstweek.WebApp.Data;
using Master.Firstweek.WebApp.Service;
using Microsoft.AspNetCore.Components;

namespace Master.Firstweek.WebApp.Components.Pages;

public partial class AddPayment : ComponentBase
{
    [Inject] private BillService BillService  { get; set; }
 
    private Bill? Bill { get; set; }
    protected override async Task OnInitializedAsync()
    {
        Bill = await BillService.GetBill(BillId); 
    }
}