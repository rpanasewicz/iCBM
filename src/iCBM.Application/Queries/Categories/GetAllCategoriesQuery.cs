using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.Application.Queries.Categories
{
    public class GetAllCategoriesQuery : IQuery<List<CategoryDto>>
    {
    }

    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<List<CategoryDto>> Handle(GetAllCategoriesQuery query)
            => _ctx.Categories.ProjectToListAsync<CategoryDto>(_mapper.ConfigurationProvider);
    }


    public class CategoryDto : IMapFrom<Category>
    {
        public string Name { get; }
        public Color Color { get; }
        public string Icon { get; }

        private CategoryDto() { }
        
        public CategoryDto(string name, Color color, string icon)
        {
            Name = name;
            Color = color;
            Icon = icon;
        }
    }
}
