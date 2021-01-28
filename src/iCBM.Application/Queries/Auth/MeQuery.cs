using AutoMapper;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Misio.Common.Auth.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCBM.Application.Queries.Auth
{
    public class MeQuery : IQuery<MeDto>
    {
    }

    public class MeQueryHandler : IQueryHandler<MeQuery, MeDto>
    {
        private readonly IAuthProvider _auth;
        private readonly ICbmContext _ctx;
        private readonly IMapper _mapper;

        public MeQueryHandler(IAuthProvider auth, ICbmContext ctx, IMapper mapper)
        {
            _auth = auth;
            _ctx = ctx;
            _mapper = mapper;
        }

        public Task<MeDto> Handle(MeQuery query) =>
        
            _mapper.ProjectTo<MeDto>(_ctx.Users.Where(u => u.Id == _auth.UserId)).FirstOrDefaultAsync();
        
    }

    public class MeDto : IMapFrom<User>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public MeDto(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
