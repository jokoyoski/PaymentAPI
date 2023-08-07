using System.ComponentModel.DataAnnotations;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Entities;

public class Merchant : IMerchant
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Code { get; set; }

    public bool IsActive { get; set; }
}