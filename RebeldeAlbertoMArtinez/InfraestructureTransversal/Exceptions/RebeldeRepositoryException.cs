using System;

namespace RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions
{
    public class RebeldeRepositoryException : Exception
    {
        public RebeldeRepositoryException() : base("Fallo en en el Repository") { }
        public RebeldeRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
