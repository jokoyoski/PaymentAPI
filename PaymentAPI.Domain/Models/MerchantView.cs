using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class MerchantView : IMerchantView
{
    /// <summary>
    /// 
    /// </summary>
    public  Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>

    public bool IsActive { get; set; }
}