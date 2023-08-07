using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Repository;

public class BankRepository : IBankRepository
{
    private readonly IMapper _mapper;
    public PaymentAPIDbContext _context { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public BankRepository(PaymentAPIDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper;
    }
    
    public async Task<IBank> GetBankBySortCode(string sortCode)
    {
        var bank = await _context.Banks.FirstOrDefaultAsync(x => x.SortCode == sortCode);
        
        return _mapper.Map<IBank>(bank);
    }
}