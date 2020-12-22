using Microsoft.EntityFrameworkCore;
using Misio.Common.Auth.Abstractions;
using Misio.Common.Auth.Types;
using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Auth
{
    public class SignInCommand : ICommand<JsonWebToken>
    {
        public string Email { get; }
        public string Password { get; }

        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class SignInCommandHandler : ICommandHandler<SignInCommand, JsonWebToken>
    {
        private readonly ICbmContext _context;
        private readonly IPasswordService _passwordService;
        private readonly IJwtHandler _jwtHandler;

        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public SignInCommandHandler(IPasswordService passwordService, IJwtHandler jwtHandler, ICbmContext context)
        {
            _passwordService = passwordService;
            _jwtHandler = jwtHandler;
            _context = context;
        }

        public async Task<JsonWebToken> Handle(SignInCommand cmd)
        {
            if (!EmailRegex.IsMatch(cmd.Email))
            {
                throw new Exception(cmd.Email);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == cmd.Email);

            if (user is null || !_passwordService.IsValid(user.Password, cmd.Password))
            {
                throw new Exception("Invalid credentials");
            }

            var claims = new Dictionary<string, IEnumerable<string>>
            {
                ["firstName"] = new[] { user.FirstName },
                ["lastName"] = new[] { user.LastName },
            };

            return _jwtHandler.CreateToken(user.Id.ToString(), "role", claims);
        }
    }
}