using iCBM.Application.Exceptions;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Misio.Common.Auth.Abstractions;
using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Notifications
{
    public class MarkNotificationReadCommand : ICommand
    {
        public Guid NotificationId { get; }

        public MarkNotificationReadCommand(Guid notificationId)
        {
            NotificationId = notificationId;
        }
    }

    public class MarkNotificationReadCommandHandler : ICommandHandler<MarkNotificationReadCommand>
    {
        private readonly IAuthProvider _auth;
        private readonly ICbmContext _context;

        public MarkNotificationReadCommandHandler(IAuthProvider auth, ICbmContext context)
        {
            _auth = auth;
            _context = context;
        }

        public async Task<Unit> Handle(MarkNotificationReadCommand cmd)
        {
            if (await _context.NotificationReads.AnyAsync(nr =>
                nr.UserId == _auth.UserId && nr.NotificationId == cmd.NotificationId))
                return Unit.Value;

            var user = await _context.Users.FindAsync(_auth.UserId);
            var notification = await _context.Notifications.FindAsync(cmd.NotificationId);

            if (user is null)
                throw new ResourceNotFoundException(nameof(User), _auth.UserId);

            if (notification is null)
                throw new ResourceNotFoundException(nameof(Notification), cmd.NotificationId);

            await _context.NotificationReads.AddAsync(NotificationReads.New(user, notification, DateTime.UtcNow));

            return Unit.Value;
        }
    }
}
