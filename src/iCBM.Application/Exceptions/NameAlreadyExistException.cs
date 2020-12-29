using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCBM.Application.Exceptions
{
    public class NameAlreadyExistException : Exception
    {
        public NameAlreadyExistException(string resourceName, string name) : base(
            $"The resource ({resourceName}) with the name ({name}) already exist.")
        {
            
        }
    }
}
