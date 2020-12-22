using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;

namespace iCBM.Application.Queries.Expenses
{
    public class GetAllExpensesQuery : IQuery<List<ExpenseListItemDto>>
    {
    }

    public class GetAllExpensesQueryHandler : IQueryHandler<GetAllExpensesQuery, List<ExpenseListItemDto>>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<List<ExpenseListItemDto>> Handle(GetAllExpensesQuery query)
            => _ctx.Expenses.ProjectToListAsync<ExpenseListItemDto>(_mapper.ConfigurationProvider);
    }
}