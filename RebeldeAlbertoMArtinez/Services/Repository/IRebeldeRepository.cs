using RebeldeAlbertoMArtinez.Models;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace RebeldeAlbertoMArtinez.Services.Repository
{
    public interface IRebeldeRepository
    {
        IEnumerable<Rebelde> ListaRebeldes { get; }
        void Create(StringCollection collection);
    }
}
