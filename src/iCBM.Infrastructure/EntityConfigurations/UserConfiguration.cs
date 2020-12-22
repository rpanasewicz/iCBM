using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : EntityConfigurationBase<User>
    {
        public override void ConfigureFields(EntityTypeBuilder<User> entity)
        {
        }

        public override void ConfigureRelationships(EntityTypeBuilder<User> entity)
        {

        }
    }
}
