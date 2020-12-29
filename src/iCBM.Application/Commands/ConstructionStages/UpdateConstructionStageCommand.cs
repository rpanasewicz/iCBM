using System;
using System.Threading.Tasks;
using iCBM.Application.Exceptions;
using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Domain.Types;

namespace iCBM.Application.Commands.ConstructionStages
{
    public class UpdateConstructionStageCommand : ICommand
    {
        public Guid ConstructionStageId { get; }
        public string Name { get;  }
        public string Color { get; }
        public string Icon { get;  }
        public DateTime PlannedStartDate { get;  }
        public DateTime PlannedFinishDate { get;  }
        public DateTime? ActualStartDate { get;  }
        public DateTime? ActualFinishDate { get;  }

        public UpdateConstructionStageCommand(Guid constructionStageId, string name, string color, string icon, DateTime plannedStartDate, DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate)
        {
            ConstructionStageId = constructionStageId;
            Name = name;
            Color = color;
            Icon = icon;
            PlannedStartDate = plannedStartDate;
            PlannedFinishDate = plannedFinishDate;
            ActualStartDate = actualStartDate;
            ActualFinishDate = actualFinishDate;
        }
    }
    
    public class UpdateConstructionStageCommandHandler : ICommandHandler<UpdateConstructionStageCommand>
    {
        private readonly ICbmContext _context;

        public UpdateConstructionStageCommandHandler(ICbmContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateConstructionStageCommand cmd)
        {
            if (await _context.ConstructionStages.AnyAsync(s => s.Name == cmd.Name && s.Id != cmd.ConstructionStageId))
                throw new NameAlreadyExistException(nameof(ConstructionStage), cmd.Name);

            var constructionStage = await _context.ConstructionStages.FindAsync(cmd.ConstructionStageId); 
            
            constructionStage.Update(cmd.Name, Enumeration.FromDisplayName<Color>(cmd.Color),
                cmd.Icon, cmd.PlannedStartDate, cmd.PlannedFinishDate, cmd.ActualStartDate, cmd.ActualFinishDate);
            
            return Unit.Value;
        }
    }
}
