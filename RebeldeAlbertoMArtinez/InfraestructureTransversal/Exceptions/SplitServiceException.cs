using System;

namespace RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions
{
    public class SplitServiceException : Exception
    {
        public SplitServiceException() : base() { }
        public SplitServiceException(string message) : base(message) { }
        public SplitServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
