using iCBM.Domain.Common;
using iCBM.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iCBM.Domain.Models
{
    public class Supplier : OwnedEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ContactDetails ContactDetails { get; }

        private ISet<Expense> _expenses;

        public IEnumerable<Expense> Expenses
        {
            get => _expenses.AsEnumerable();
            private set => _expenses = new HashSet<Expense>(value);
        }

        private Supplier()
        {
        } // For EF

        private Supplier(Guid id, string name, string description, ContactDetails contactDetails, IEnumerable<Expense> expenses)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Expenses = expenses ?? throw new ArgumentNullException(nameof(expenses));
            Description = description;
            ContactDetails = contactDetails;
        }

        public static Supplier New(string name, string description, ContactDetails contactDetails)
        {
            return new Supplier(Guid.NewGuid(), name, description, contactDetails, Enumerable.Empty<Expense>());
        }
    }
}
