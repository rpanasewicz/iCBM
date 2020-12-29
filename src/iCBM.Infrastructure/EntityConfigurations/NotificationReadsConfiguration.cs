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
    public class NotificationReadsConfiguration : EntityConfigurationBase<NotificationReads>
    {
        public NotificationReadsConfiguration(DbContextBase context) : base(context)
        {
        }

        public override void ConfigureFields(EntityTypeBuilder<NotificationReads> entity)
        {
            entity.HasKey(e => new { e.UserId, e.NotificationId });
        }

        public override void ConfigureRelationships(EntityTypeBuilder<NotificationReads> entity)
        {
        }
    }
}
