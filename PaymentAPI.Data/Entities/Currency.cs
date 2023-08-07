using System.ComponentModel.DataAnnotations;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Entities;

public class Currency : ICurrency
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Code { get; set; }
}