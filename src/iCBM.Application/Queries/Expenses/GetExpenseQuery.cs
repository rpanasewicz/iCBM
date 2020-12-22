using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using iCBM.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.Application.Queries.Expenses
{
    public class GetExpenseQuery : IQuery<ExpenseDto>
    {
        public Guid ExpenseId { get; }
        
        public GetExpenseQuery(Guid expenseId)
        {
            ExpenseId = expenseId;
        }
    }

    public class GetExpenseQueryHandler : IQueryHandler<GetExpenseQuery, ExpenseDto>
    {
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public GetExpenseQueryHandler(ICbmContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        
        public async Task<ExpenseDto> Handle(GetExpenseQuery query)
        {
            var expense = await _ctx.Expenses.Where(e => e.Id == query.ExpenseId).Include(a => a.Category).Include(a => a.Supplier).FirstOrDefaultAsync();
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
