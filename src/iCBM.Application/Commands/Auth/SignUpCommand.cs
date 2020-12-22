using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Misio.Common.Auth.Abstractions;
using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Auth
{
    public class SignUpCommand : ICommand
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public SignUpCommand(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }

    public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
    {
        private readonly ICbmContext _context;
        private readonly IPasswordService _passwordService;

        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public SignUpCommandHandler(IPasswordService passwordService, ICbmContext context)
        {
            _passwordService = passwordService;
            _context = context;
        }

        public async Task<Unit> Handle(SignUpCommand cmd)
        {
            if (string.IsNullOrEmpty(cmd.Email) || !EmailRegex.IsMatch(cmd.Email))
            {
                throw new Exception($"Invalid email: {cmd.Email}");
            }

            var exist = await _context.Users.AnyAsync(a => a.Email.Equals(cmd.Email));
            if (exist)
            {
                throw new Exception($"Email already in use: {cmd.Email}");
            }

            var passwordHash = _passwordService.Hash(cmd.Password);

            var user = User.New(cmd.FirstName, cmd.LastName, cmd.Email, passwordHash);
            await _context.Users.AddAsync(user);

            return Unit.Value;
        }
    }
}
