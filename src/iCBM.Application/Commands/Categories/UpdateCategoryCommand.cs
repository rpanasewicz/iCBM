using iCBM.Domain.Enums;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Domain.Types;
using System;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Categories
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid CategoryId { get; }
        public string Name { get; }
        public string Color { get; }
        public string Icon { get; }

        public UpdateCategoryCommand(Guid categoryId, string name, string color, string icon)
        {
            Name = name;
            Color = color;
            Icon = icon;
            CategoryId = categoryId;
        }
    }

    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly ICbmContext _ctx;

        public UpdateCategoryCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand cmd)
        {
            var category = await _ctx.Categories.FindAsync(cmd.CategoryId);

            category.Update(cmd.Name, Enumeration.FromDisplayName<Color>(cmd.Color), cmd.Icon);

            return Unit.Value;
        }
    }
}