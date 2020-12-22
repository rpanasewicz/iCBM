using iCBM.Application.Commands.Categories;
using iCBM.Application.Queries.Categories;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CategoriesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _queryDispatcher.QueryAsync(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/expenses/{result:N}", result);
        }

        [HttpPut("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Ok();
        }
    }
}
