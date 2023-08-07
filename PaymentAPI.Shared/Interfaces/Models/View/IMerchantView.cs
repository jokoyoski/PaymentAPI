namespace PaymentAPI.Shared.Interfaces.View;

public interface IMerchantView
{
     Guid   Id { get; set; }
    
     string Name { get; set; }
    
     string Code { get; set; }

     bool IsActive { get; set; }
}