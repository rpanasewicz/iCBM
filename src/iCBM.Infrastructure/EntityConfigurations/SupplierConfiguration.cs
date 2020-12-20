using System.Collections.Generic;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class SupplierConfiguration : BaseEntityConfiguration<Supplier>
    {
        public override string TableName => "Supplier";
        public override string PrimaryKeyColumnName => "Id";

        public override void ConfigureFields(EntityTypeBuilder<Supplier> entity)
        {
            entity.OwnsOne(s => s.ContactDetails, builder =>
            {
                builder.Property(c => c.AddressLine1)
                    .HasMaxLength(248)
                    .HasColumnName("AddressLine1");

                builder.Property(c => c.AddressLine2)
                    .HasMaxLength(248)
                    .HasColumnName("AddressLine2");

                builder.Property(c => c.City)
                    .HasMaxLength(32)
                    .HasColumnName("City");


                builder.Property(c => c.EmailAddress)
                    .HasMaxLength(248)
                    .HasColumnName("EmailAddress");

                builder.Property(c => c.Zipcode)
                    .HasMaxLength(8)
                    .HasColumnName("Zipcode");

                builder.Property(c => c.PhoneNumber)
                    .HasMaxLength(16)
                    .HasColumnName("PhoneNumber");
            });
        }

        public override void ConfigureRelationships(EntityTypeBuilder<Supplier> entity)
        {
        }

        public override IEnumerable<Supplier> SeedData => new List<Supplier>();
    }
}
