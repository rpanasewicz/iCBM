using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;
using System.Collections.Generic;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class ExpenseConfiguration : BaseEntityConfiguration<Expense>
    {
        public override string TableName => "Expenses";
        public override string PrimaryKeyColumnName => "Id";

        public override void ConfigureFields(EntityTypeBuilder<Expense> entity)
        {
            entity.OwnsOne(e => e.Amount)
                .Property(c => c.Amount)
                .HasPrecision(38, 2)
                .HasColumnName("Amount");

            entity.OwnsOne(e => e.Amount)
                .Property(c => c.CurrencyId)
                .HasColumnName("CurrencyId");

            entity.OwnsOne(e => e.Amount)
                .Ignore(c => c.Currency);
        }

        public override void ConfigureRelationships(EntityTypeBuilder<Expense> entity)
        {
        }

        public override IEnumerable<Expense> SeedData => new List<Expense>();
    }
}
