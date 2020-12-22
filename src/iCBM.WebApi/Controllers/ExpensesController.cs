using System;
using iCBM.Application.Commands.Expenses;
using iCBM.Application.Queries.Expenses;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.Auth.Attributes;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [JwtAuth]
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ExpensesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewExpense(AddExpenseCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/expenses/{result:N}", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _queryDispatcher.QueryAsync(new GetAllExpensesQuery()));
        }

        [HttpGet("{expenseId}")]
        public async Task<IActionResult> Get(Guid expenseId)
        {
            return Ok(await _queryDispatcher.QueryAsync(new GetExpenseQuery(expenseId)));
        }
    }
}
