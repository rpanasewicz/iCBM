using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iCBM.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;

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
            await _commandDispatcher.SendAsync(cmd);
            return Ok();
        }
    }
}
