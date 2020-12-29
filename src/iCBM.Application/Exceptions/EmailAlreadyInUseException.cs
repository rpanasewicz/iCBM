using System;

namespace iCBM.Application.Exceptions
{
    public class EmailAlreadyInUseException : Exception
    {
        public EmailAlreadyInUseException(string email) : base($"Email already in use: {email}")
        {

        }
    }
}
