using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;
using System;

namespace iCBM.Application.Dtos
{
    public class CategoryDto : IMapFrom<Category>
    {
        public Guid Id { get; }
        public string Name { get; }
        public ColorDto Color { get; }
        public string Icon { get; }

        public CategoryDto(Guid id, string name, ColorDto color, string icon)
        {
            Id = id;
            Name = name;
            Color = color;
            Icon = icon;
        }
    }
}