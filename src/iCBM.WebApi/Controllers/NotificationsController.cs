using iCBM.Application.Commands.Notifications;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.Auth.Attributes;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;

namespace iCBM.WebApi.Controllers
{
    [JwtAuth]
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public NotificationsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationCommand cmd)
        {
            var notificationId = await _commandDispatcher.SendAsync(cmd);
            return Created($"notifications/{notificationId}", notificationId);
        }

        [HttpPost("{notificationId}/markRead")]
        public async Task<IActionResult> MarkRead(MarkNotificationReadCommand cmd)
        {
            await _commandDispatcher.SendAsync(cmd);
            return Ok();
        }
    }
}