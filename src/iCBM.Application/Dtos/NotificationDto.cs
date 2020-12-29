using System;
using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class NotificationDto : IMapFrom<Notification>
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Body { get; }

        public NotificationDto(Guid id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
    }
}