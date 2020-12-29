using System;
using System.Collections.Generic;
using System.Linq;
using iCBM.Domain.Common;

namespace iCBM.Domain.Models
{
    public class Notification : EntityBase
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime PublishDated { get; private set; }
        public DateTime? ExpirationDate { get; private set; }

        private ISet<NotificationReads> _reads;
        
        public IEnumerable<NotificationReads> Reads
        {
            get => _reads.AsEnumerable();
            private set => _reads = new HashSet<NotificationReads>(value);
        }
        
        private Notification() { } // For EF

        private Notification(Guid id, string title, string body, DateTime publishDated, DateTime? expirationDate, IEnumerable<NotificationReads> reads)
        {
            Id = id;
            Title = title;
            Body = body;
            PublishDated = publishDated;
            ExpirationDate = expirationDate;
            Reads = reads;
        }

        public static Notification New(string title, string body, DateTime publishDated, DateTime? expirationDate)
        {
            return new(Guid.NewGuid(), title, body, publishDated, expirationDate, Enumerable.Empty<NotificationReads>());
        }

        public void MarkRead(User user)
        {
            _reads.Add(NotificationReads.New(user, this, DateTime.UtcNow));
        }
    }
}
