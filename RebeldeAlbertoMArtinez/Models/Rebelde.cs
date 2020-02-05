

namespace RebeldeAlbertoMArtinez.Models
{
    public class Rebelde
    {
        public string Nombre { get; set; }
        public string Planeta { get; set; }

        public Rebelde(string nombre, string planeta)
        {
            Nombre = nombre;
            Planeta = planeta;
        }
    }
}
