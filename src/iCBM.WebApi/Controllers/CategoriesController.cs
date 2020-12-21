using System.Threading.Tasks;
using iCBM.Application.Commands.Categories;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CategoriesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/expenses/{result:N}", result);
        }

        [HttpPut("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategory(AddCategoryCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Created($"/expenses/{result:N}", result);
        }
    }
}
