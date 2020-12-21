using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : EntityConfigurationBase<Category>
    {
        public override void ConfigureFields(EntityTypeBuilder<Category> entity)
        {
            
        }

        public override void ConfigureRelationships(EntityTypeBuilder<Category> entity)
        {
           
        }
    }
}
