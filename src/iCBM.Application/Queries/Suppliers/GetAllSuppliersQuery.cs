using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCBM.Application.Queries.Suppliers
{
    public class GetAllSuppliersQuery : IQuery<List<SupplierDto>>
    {
    }

    public class GetAllSuppliersQueryHandler : IQueryHandler<GetAllSuppliersQuery, List<SupplierDto>>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<List<SupplierDto>> Handle(GetAllSuppliersQuery query)
            => _ctx.Suppliers.ProjectToListAsync<SupplierDto>(_mapper.ConfigurationProvider);
    }
}
