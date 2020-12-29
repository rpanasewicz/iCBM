using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class NotificationConfiguration : EntityConfigurationBase<Notification>
    {
        public NotificationConfiguration(DbContextBase context) : base(context)
        {
        }

        public override void ConfigureFields(EntityTypeBuilder<Notification> entity)
        {

        }

        public override void ConfigureRelationships(EntityTypeBuilder<Notification> entity)
        {
        }
    }
}
