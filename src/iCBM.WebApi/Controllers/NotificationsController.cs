using iCBM.Application.Commands.Notifications;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.Auth.Attributes;
using Misio.Common.CQRS.Commands.Abstractions;
using System.Threading.Tasks;
using iCBM.Application.Queries.Notifications;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.WebApi.Controllers
{
    [JwtAuth]
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public NotificationsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
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

        [HttpGet("/me/notifications")]
        public async Task<IActionResult> GetMyNotifications()
        {
            var result = await _queryDispatcher.QueryAsync(new GetMyNotificationsQuery());
            return Ok(result);
        }
    }
}