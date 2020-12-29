using System;

namespace iCBM.Application.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string resourceName, string resourceId) : base($"Resource ({resourceName}) wit Id ({resourceId}) not found.")
        {

        }

        public ResourceNotFoundException(string resourceName, Guid resourceId) : this(resourceName, resourceId.ToString("N"))
        {

        }
    }
}
