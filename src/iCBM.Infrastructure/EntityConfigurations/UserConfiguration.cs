using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public override IEnumerable<(Guid, User, Guid?)> SeedData
            => new (Guid, User, Guid?)[]
            {
                (
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6"),
                    User.New("Harry", "Potter", "harry@example.com",
                        "AQAAAAEAACcQAAAAEAgypWPs8S/vBidt0j/vANTzN25W/BkUbO/MhGadoWBpCcEhFvnJ5VUV+lPLHBQq/Q=="),
                    null
                )
            };

        public UserConfiguration(DbContextBase context) : base(context)
        {
        }
    }
}
