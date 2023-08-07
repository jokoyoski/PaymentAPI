namespace PaymentAPI.Shared.Interfaces;

public interface IMerchant
{
    /// <summary>
    /// 
    /// </summary>
    Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    bool IsActive { get; set; }
}