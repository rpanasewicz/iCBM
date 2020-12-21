using iCBM.Application.Commands.Suppliers;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public SuppliersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSupplier(AddSupplierCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/suppliers/{result:N}", result);
        }
    }
}
