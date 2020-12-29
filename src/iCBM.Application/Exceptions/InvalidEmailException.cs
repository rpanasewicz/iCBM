using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCBM.Application.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email: {email}")
        {

        }
    }
}
