using iCBM.Application.Commands.Auth;
using iCBM.Application.Queries.Auth;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.Auth.Attributes;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher queryDispatcher;

        public AuthController(ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
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

        [JwtAuth]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            return Ok(await queryDispatcher.QueryAsync(new MeQuery()));
        }
    }
}
