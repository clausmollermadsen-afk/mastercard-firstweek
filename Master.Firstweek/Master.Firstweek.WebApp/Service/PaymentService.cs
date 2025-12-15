using Master.Firstweek.WebApp.Data;

namespace Master.Firstweek.WebApp.Service;

public class PaymentService
{
    private readonly ApplicationDbContext _context;

    public PaymentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddPayment(Bill bill)
    {
        
    }
}