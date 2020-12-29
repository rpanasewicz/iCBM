using iCBM.Domain.Models;
using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Notifications
{
    public class CreateNotificationCommand : ICommand<Guid>
    {
        public string Title { get; }
        public string Body { get; }
        public DateTime PublishDated { get; }
        public DateTime? ExpirationDate { get; }

        public CreateNotificationCommand(string title, string body, DateTime publishDated, DateTime? expirationDate)
        {
            Title = title;
            Body = body;
            PublishDated = publishDated;
            ExpirationDate = expirationDate;
        }
    }

    public class CreateNotificationCommandHandler : ICommandHandler<CreateNotificationCommand, Guid>
    {
        private readonly ICbmContext _context;

        public CreateNotificationCommandHandler(ICbmContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNotificationCommand cmd)
        {
            var notification = Notification.New(cmd.Title, cmd.Body, cmd.PublishDated, cmd.ExpirationDate);
            await _context.Notifications.AddAsync(notification);
            return notification.Id;
        }
    }
}
