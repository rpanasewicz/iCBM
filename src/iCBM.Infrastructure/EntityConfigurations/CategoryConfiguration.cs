using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        }

        public override IDictionary<Guid, Category> SeedData
            => new Dictionary<Guid, Category>()
                {
                    {new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"), Category.New("Materials", Color.Blue, "shop")},
                    {new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"), Category.New("Services", Color.Red, "shop")},
                    {new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"), Category.New("Other", Color.Yellow, "shop")}
                };
    }
}
