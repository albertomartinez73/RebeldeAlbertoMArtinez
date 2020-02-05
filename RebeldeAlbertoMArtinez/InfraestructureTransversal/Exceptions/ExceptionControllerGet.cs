using System;

namespace RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions
{
    public class ExceptionControllerGet : Exception
    {
        public ExceptionControllerGet() : base("Fallo en metodo Get del RebeldeController") { }
        public ExceptionControllerGet(string message, Exception innerException) : base(message, innerException) { }
    }
}
