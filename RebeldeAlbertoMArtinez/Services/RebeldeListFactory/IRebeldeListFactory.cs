using RebeldeAlbertoMArtinez.Models;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace RebeldeAlbertoMArtinez.Services.RebeldeListFactory
{
    interface IRebeldeListFactory
    {
        IEnumerable<Rebelde> CreateList(StringCollection collection);
    }
}
