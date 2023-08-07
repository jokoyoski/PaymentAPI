using System.ComponentModel.DataAnnotations;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Entities;

public class Bank 
{
   [Key]
   public Guid Id { get; set; } 
   public string BankName { get; set; }
   public string SortCode { get; set; }
   public bool IsActive { get; set; }
}