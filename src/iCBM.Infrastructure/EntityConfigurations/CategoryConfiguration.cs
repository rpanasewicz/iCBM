using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : EntityConfigurationBase<Category>
    {
        public override void ConfigureFields(EntityTypeBuilder<Category> entity)
        {
            entity.Ignore(e => e.Color);
        }

        public override void ConfigureRelationships(EntityTypeBuilder<Category> entity)
        {
            entity.HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public override IEnumerable<(Guid, Category, Guid?)> SeedData
            => new (Guid, Category, Guid?)[]
            {
                (
                    new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                    Category.New("Materials", Color.Blue, "shop"),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                ),
                (
                    new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                    Category.New("Services", Color.Red, "shop"),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                ),
                (
                    new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                    Category.New("Other", Color.Yellow, "shop"),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                )
            };

        public CategoryConfiguration(DbContextBase context) : base(context)
        {
        }
    }
}
