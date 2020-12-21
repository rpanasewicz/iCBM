using iCBM.Domain.Enums;
using Misio.Domain.Types;

namespace iCBM.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public int CurrencyId { get; private set; }

        public Currency Currency
        {
            get => Enumeration.FromValue<Currency>(CurrencyId);
            private init => CurrencyId = value.Id;
        }

        private Money() { } // For EF

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
