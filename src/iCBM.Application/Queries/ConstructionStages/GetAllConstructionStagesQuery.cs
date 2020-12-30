using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;

namespace iCBM.Application.Queries.ConstructionStages
{
    public class GetAllConstructionStagesQuery : IQuery<List<ConstructionStageDto>>
    {
    }
    
    public class GetAllConstructionStagesQueryHandler : IQueryHandler<GetAllConstructionStagesQuery, List<ConstructionStageDto>>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetAllConstructionStagesQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<List<ConstructionStageDto>> Handle(GetAllConstructionStagesQuery query)
            => _ctx.ConstructionStages.ProjectToListAsync<ConstructionStageDto>(_mapper.ConfigurationProvider);
    }
}
