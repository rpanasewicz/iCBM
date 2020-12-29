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
    public class AddNewConstructionStageCommand : ICommand<Guid>
    {
        public string Name { get;  }
        public string Color { get; }
        public string Icon { get;  }
        public DateTime PlannedStartDate { get;  }
        public DateTime PlannedFinishDate { get;  }
        public DateTime? ActualStartDate { get;  }
        public DateTime? ActualFinishDate { get;  }

        public AddNewConstructionStageCommand(string name, string color, string icon, DateTime plannedStartDate,
            DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate)
        {
            Name = name;
            Color = color;
            Icon = icon;
            PlannedStartDate = plannedStartDate;
            PlannedFinishDate = plannedFinishDate;
            ActualStartDate = actualStartDate;
            ActualFinishDate = actualFinishDate;
        }
    }
    
    public class AddNewConstructionStageCommandHandler : ICommandHandler<AddNewConstructionStageCommand, Guid>
    {
        private readonly ICbmContext _context;

        public AddNewConstructionStageCommandHandler(ICbmContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddNewConstructionStageCommand cmd)
        {
            if (await _context.ConstructionStages.AnyAsync(s => s.Name == cmd.Name))
                throw new NameAlreadyExistException(nameof(ConstructionStage), cmd.Name);

            var constructionStage = ConstructionStage.New(cmd.Name, Enumeration.FromDisplayName<Color>(cmd.Color),
                cmd.Icon, cmd.PlannedStartDate, cmd.PlannedFinishDate, cmd.ActualStartDate, cmd.ActualFinishDate);

            await _context.ConstructionStages.AddAsync(constructionStage);

            return constructionStage.Id;
        }
    }
}
