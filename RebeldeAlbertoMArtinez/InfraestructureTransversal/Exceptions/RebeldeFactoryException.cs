using System;

namespace RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions
{
    public class RebeldeFactoryException : Exception
    {
        public RebeldeFactoryException() : base() { }
        public RebeldeFactoryException(string message) : base(message) { }
        public RebeldeFactoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
