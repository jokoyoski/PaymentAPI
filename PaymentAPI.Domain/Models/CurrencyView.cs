using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class CurrencyView : ICurrencyView
{
     public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Code { get; set; }
}