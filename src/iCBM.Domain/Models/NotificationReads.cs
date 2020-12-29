using Misio.Domain.Types;
using System;

namespace iCBM.Domain.Models
{
    public class NotificationReads : Entity
    {
        public Guid UserId { get; private set; }
        public Guid NotificationId { get; private set; }
        public DateTime ReadOn { get; private set; }

        public User User { get; private set; }
        public Notification Notification { get; private set; }

        private NotificationReads() { }

        private NotificationReads(User user, Notification notification, DateTime readOn)
        {
            UserId = user.Id;
            NotificationId = notification.Id;
            User = user;
            Notification = notification;
            ReadOn = readOn;
        }

        public static NotificationReads New(User user, Notification notification, DateTime readOn)
        {
            return new NotificationReads(user, notification, readOn);
        }
    }
}
