using iCBM.Domain.ValueObjects;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class MoneyDto : IMapFrom<Money>
    {
        public decimal Amount { get; }
        public int CurrencyId { get; }

        public MoneyDto(decimal amount, int currencyId)
        {
            Amount = amount;
            CurrencyId = currencyId;
        }
    }
}