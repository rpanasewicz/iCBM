using System;
using System.Collections.Generic;
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

        public override IEnumerable<(Guid, Notification, Guid?)> SeedData
            => new (Guid, Notification, Guid?)[]
            {
                (
                    Guid.Parse("622df3c9-812b-4e4f-bdff-91193d61149a"),
                    Notification.New("Hello, welcome to iCBM", "Thanks for joining.", new DateTime(2021, 1, 1), null),
                    null
                )
            };
    }
}
