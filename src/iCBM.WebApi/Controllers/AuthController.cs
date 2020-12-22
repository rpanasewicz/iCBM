using iCBM.Application.Commands.Categories;
using iCBM.Application.Queries.Categories;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using System.Threading.Tasks;
using iCBM.Application.Commands.Auth;
using Misio.Common.Auth.Attributes;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AuthController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Ok(result);
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> UpdateCategory(SignUpCommand cmd)
        {
            var result = await _commandDispatcher.SendAsync(cmd);
            return Ok();
        }
    }
}
