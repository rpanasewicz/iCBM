using iCBM.Application.Commands.Expenses;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;
using iCBM.Application.Queries.Expenses;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
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
    }
}
