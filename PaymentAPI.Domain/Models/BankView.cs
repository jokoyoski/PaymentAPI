using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class BankView : IBankView
{
    public Guid Id { get; set; }
    public string BankName { get; set; }
    public string SortCode { get; set; }
    public bool IsActive { get; set; }
}