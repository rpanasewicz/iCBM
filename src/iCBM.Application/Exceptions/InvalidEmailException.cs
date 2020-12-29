using System;

namespace iCBM.Application.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email: {email}")
        {

        }
    }
}
