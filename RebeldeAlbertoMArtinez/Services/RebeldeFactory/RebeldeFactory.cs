using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;
using RebeldeAlbertoMArtinez.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RebeldeAlbertoMArtinez.Services.SplitService;

namespace RebeldeAlbertoMArtinez.Services.RebeldeFactory
{
    public class RebeldeFactory : IRebeldeFactory
    {

        private readonly IEnumerable<Rebelde> _listRebeldes;
        private Rebelde _rebelde;
        private readonly ISplitService _split;

        public RebeldeFactory(ISplitService split)
        {
            _split = split;
        }

        public Rebelde Create(StringCollection collection)
        {
            try
            {
                var cadena = _split.Convert(collection[0], ',');
                _rebelde = new Rebelde(cadena[0], cadena[1]);
                return _rebelde;
            }
            catch (Exception e)
            {
                throw new RebeldeFactoryException("Error en RebeldeFactory metodo Create ", e);
            }
            
            
        }
    }
}
