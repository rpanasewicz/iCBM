using iCBM.Application.Commands.Auth;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SignUp(SignUpCommand cmd)
        {
            await _commandDispatcher.SendAsync(cmd);
            return Ok();
        }
    }
}
