using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class ExpenseConfiguration : EntityConfigurationBase<Expense>
    {
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
            entity.HasOne(e => e.Supplier)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.SupplierId);

            entity.HasOne(e => e.Category)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.CategoryId);

            entity.HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public ExpenseConfiguration(DbContextBase context) : base(context)
        {
        }
    }
}
