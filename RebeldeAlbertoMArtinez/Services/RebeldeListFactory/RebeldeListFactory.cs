using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using RebeldeAlbertoMArtinez.Models;
using RebeldeAlbertoMArtinez.Services.SplitService;

namespace RebeldeAlbertoMArtinez.Services.RebeldeListFactory
{
    public class RebeldeListFactory : IRebeldeListFactory
    {
        private IEnumerable<Rebelde> _listRebeldes;
        private Rebelde _rebelde { get; set; }
        private readonly ISplitService _split;

        public RebeldeListFactory(ISplitService split)
        {
            _split = split;
        }

        public IEnumerable<Rebelde> CreateList(StringCollection collection)
        {
            foreach (var item in collection)
            {
                var cadena = _split.Convert(item, ',');
                _listRebeldes.Append(_rebelde = new Rebelde(cadena[0], cadena[1]));
            }

            return _listRebeldes;
        }
    }
}
