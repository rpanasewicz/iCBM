using Misio.Domain.CQRS;
using System;

namespace iCBM.Domain.Models
{
    public class Expense : EntityEventPublisher
    {
        public string Name { get; }
        public string Description { get; }
        public Money Amount { get; }
        public DateTime ExpenseTime { get; }

        private Expense() { } // For EF

        private Expense(Guid id, string name, string description, Money amount, DateTime expenseTime)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            
            Id = id;
            Name = name;
            Description = description;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            ExpenseTime = expenseTime;
        }

        public static Expense New(string name, string description, Money amount, DateTime expenseTime)
        {
            return new Expense(Guid.NewGuid(), name, description, amount, expenseTime);
        }
    }
}
