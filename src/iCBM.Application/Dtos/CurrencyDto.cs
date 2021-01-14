using iCBM.Domain.Enums;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class CurrencyDto : IMapFrom<Currency>
    {
        public string Name { get; }
        public int Id { get; }

        public CurrencyDto(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}