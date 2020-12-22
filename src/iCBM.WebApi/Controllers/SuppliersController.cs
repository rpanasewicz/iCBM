using iCBM.Application.Commands.Suppliers;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;
using iCBM.Application.Queries.Suppliers;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SuppliersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers() 
            => Ok(await _queryDispatcher.QueryAsync(new GetAllSuppliersQuery()));

        [HttpPost]
        public async Task<IActionResult> CreateNewSupplier(AddSupplierCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/suppliers/{result:N}", result);
        }
    }
}
