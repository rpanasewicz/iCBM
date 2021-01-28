using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class ConstructionStageConfiguration : EntityConfigurationBase<ConstructionStage>
    {
        public ConstructionStageConfiguration(DbContextBase context) : base(context)
        {
        }

        public override void ConfigureFields(EntityTypeBuilder<ConstructionStage> entity)
        {
            entity.Ignore(e => e.Color);
        }

        public override void ConfigureRelationships(EntityTypeBuilder<ConstructionStage> entity)
        {
        }

        public override IEnumerable<(Guid, ConstructionStage, Guid?)> SeedData
            => new (Guid, ConstructionStage, Guid?)[]
            {
                (
                    Guid.Parse("3a4d56e5-c062-4484-92d9-4a2347eaf809"),
                    ConstructionStage.New("SSO", Color.Green, "house", Convert.ToDateTime("2021-05-01"),
                        Convert.ToDateTime("2021-09-01"), null, null),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                ),
                (
                    Guid.Parse("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                    ConstructionStage.New("SSZ", Color.Indigo, "house", Convert.ToDateTime("2021-09-01"),
                        Convert.ToDateTime("2021-12-01"), null, null),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                ),
                (
                    Guid.Parse("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                    ConstructionStage.New("Finishing", Color.Yellow, "house", Convert.ToDateTime("2022-01-01"),
                        Convert.ToDateTime("2022-05-01"), null, null),
                    Guid.Parse("AF76108B-11EE-448B-907F-0DCACCC8ADF6")
                )
            };
    }
}
