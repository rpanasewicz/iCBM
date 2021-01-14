using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCBM.Application.Queries.Expenses
{
    public class GetAllExpensesQuery : IQuery<List<ExpenseDto>>
    {
    }

    public class GetAllExpensesQueryHandler : IQueryHandler<GetAllExpensesQuery, List<ExpenseDto>>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<List<ExpenseDto>> Handle(GetAllExpensesQuery query)
            => _ctx.Expenses.ProjectToListAsync<ExpenseDto>(_mapper.ConfigurationProvider);
    }
}