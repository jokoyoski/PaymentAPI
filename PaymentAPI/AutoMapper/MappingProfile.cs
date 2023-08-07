using AutoMapper;
using PaymentAPI.Data.Entities;
using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ITransaction, Transaction>();
        CreateMap<Transaction, ITransaction>();
        CreateMap<Transaction, TransactionView>();
    }
}