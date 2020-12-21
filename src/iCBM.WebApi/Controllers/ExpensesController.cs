using iCBM.Application.Commands.Expenses;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ExpensesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewExpense(AddExpenseCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/expenses/{result:N}", result);
        }
    }
}
