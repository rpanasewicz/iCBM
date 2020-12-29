using iCBM.Domain.Common;
using iCBM.Domain.ValueObjects;
using System;

namespace iCBM.Domain.Models
{
    public class Expense : OwnedEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Amount { get; private set; }
        public DateTime ExpenseTime { get; private set; }
        public Guid? SupplierId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid ConstructionStageId { get; private set; }

        public Supplier Supplier { get; private set; }
        public Category Category { get; private set; }
        public ConstructionStage ConstructionStage { get; private set; }

        private Expense() { } // For EF

        private Expense(Guid id, string name, string description, Money amount, DateTime expenseTime, Supplier supplier, Category category, ConstructionStage constructionStage)
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
            ConstructionStage = constructionStage ?? throw new ArgumentNullException(nameof(constructionStage));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            CategoryId = category.Id;
            SupplierId = supplier?.Id;
            ConstructionStageId = constructionStage.Id;
        }

        public static Expense New(string name, string description, Money amount, DateTime expenseTime, Supplier supplier, Category category, ConstructionStage constructionStage)
        {
            return new Expense(Guid.NewGuid(), name, description, amount, expenseTime, supplier, category, constructionStage);
        }
    }
}
