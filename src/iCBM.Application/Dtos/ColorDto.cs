using iCBM.Domain.Enums;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class ColorDto : IMapFrom<Color>
    {
        public string Name { get; }
        public int Id { get; }

        public ColorDto(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}