using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iCBM.Application.Dtos;
using Misio.Common.Auth.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper;

namespace iCBM.Application.Queries.Notifications
{
    public class GetMyNotificationsQuery : IQuery<List<NotificationDto>>
    {
    }

    public class GetNewNotificationsQueryHandler : IQueryHandler<GetMyNotificationsQuery, List<NotificationDto>>
    {
        private readonly ICbmContext _context;
        private readonly IAuthProvider _authProvider;
        private readonly IMapper _mapper;

        public GetNewNotificationsQueryHandler(ICbmContext context, IAuthProvider authProvider, IMapper mapper)
        {
            _context = context;
            _authProvider = authProvider;
            _mapper = mapper;
        }

        public Task<List<NotificationDto>> Handle(GetMyNotificationsQuery query)
        {
            var userId = _authProvider.UserId;

            if (userId == default)
                throw new UnauthorizedAccessException();

            return _context.Notifications
                .Where(n => n.PublishDated < DateTime.UtcNow &&
                            (n.ExpirationDate == null || n.ExpirationDate.Value > DateTime.UtcNow) && 
                            n.Reads.All(r => r.UserId != userId))
                .ProjectToListAsync<NotificationDto>(_mapper.ConfigurationProvider);
        }
    }
}
