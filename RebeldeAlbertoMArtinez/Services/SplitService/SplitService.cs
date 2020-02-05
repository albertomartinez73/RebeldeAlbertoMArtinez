using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;

namespace RebeldeAlbertoMArtinez.Services.SplitService
{
    public class SplitService : ISplitService
    {
        public string[] Convert(string cadena, char caracter)
        {

            var arrayString = cadena.Split(caracter);

            if (arrayString.Length == 1)
            {
                throw new SplitServiceException("Error al hacer split '" + caracter + "'");
            }

            return arrayString;
        }
    }
}
