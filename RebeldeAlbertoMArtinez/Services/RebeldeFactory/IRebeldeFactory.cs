using RebeldeAlbertoMArtinez.Models;
using System.Collections.Specialized;

namespace RebeldeAlbertoMArtinez.Services.RebeldeFactory
{
    interface IRebeldeFactory
    {
        Rebelde Create(StringCollection collection);
    }
}
