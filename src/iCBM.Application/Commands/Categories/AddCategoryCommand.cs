using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Domain.Types;
using System;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Categories
{
    public class AddCategoryCommand : ICommand<Guid>
    {
        public string Name { get; }
        public string Color { get; }
        public string Icon { get; }

        public AddCategoryCommand(string name, string color, string icon)
        {
            Name = name;
            Color = color;
            Icon = icon;
        }
    }

    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand, Guid>
    {
        private readonly ICbmContext _ctx;

        public AddCategoryCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Guid> Handle(AddCategoryCommand cmd)
        {
            if (await _ctx.Categories.AnyAsync(c => c.Name.Equals(cmd.Name)))
            {
                throw new Exception();
            }

            var category = Category.New(cmd.Name, Enumeration.FromDisplayName<Color>(cmd.Color), cmd.Icon);

            await _ctx.Categories.AddAsync(category);

            return category.Id;
        }
    }
}
