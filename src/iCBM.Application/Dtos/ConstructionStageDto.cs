using System;
using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class ConstructionStageDto : IMapFrom<ConstructionStage>
    {
        public Guid Id { get; }
        public string Name { get;  }
        public ColorDto Color { get; }
        public string Icon { get;  }
        public DateTime PlannedStartDate { get;  }
        public DateTime PlannedFinishDate { get;  }
        public DateTime? ActualStartDate { get;  }
        public DateTime? ActualFinishDate { get;  }

        public ConstructionStageDto(Guid id, string name, ColorDto color, string icon, DateTime plannedStartDate,
            DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate)
        {
            Id = id;
            Name = name;
            Color = color;
            Icon = icon;
            PlannedStartDate = plannedStartDate;
            PlannedFinishDate = plannedFinishDate;
            ActualStartDate = actualStartDate;
            ActualFinishDate = actualFinishDate;
        }
    }
}