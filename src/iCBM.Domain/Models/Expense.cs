using Misio.Domain.CQRS;
using System;
using iCBM.Domain.ValueObjects;

namespace iCBM.Domain.Models
{
    public class Expense : EntityEventPublisher
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Amount { get; private set; }
        public DateTime ExpenseTime { get; private set; }
        public Guid? SupplierId { get; private set; }
        public Guid CategoryId { get; private set; }
        
        public Supplier Supplier { get; private set; }
        public Category Category { get; private set; }

        private Expense() { } // For EF

        private Expense(Guid id, string name, string description, Money amount, DateTime expenseTime, Supplier supplier, Category category)
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
            Supplier = supplier;
            Category = category ?? throw new ArgumentNullException(nameof(category));
            CategoryId = category.Id;
            SupplierId = supplier?.Id;
        }

        public static Expense New(string name, string description, Money amount, DateTime expenseTime, Supplier supplier, Category category)
        {
            return new Expense(Guid.NewGuid(), name, description, amount, expenseTime, supplier, category);
        }
    }
}
