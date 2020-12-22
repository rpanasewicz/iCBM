using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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
}
