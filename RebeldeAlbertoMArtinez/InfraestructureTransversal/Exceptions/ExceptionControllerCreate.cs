using System;

namespace RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions
{
    public class ExceptionControllerCreate : Exception
    {
        public ExceptionControllerCreate() : base("Fallo al crear Rebelde en RebeldeController") { }
        public ExceptionControllerCreate(string message, Exception innerException) : base(message, innerException) { }
    }
}
