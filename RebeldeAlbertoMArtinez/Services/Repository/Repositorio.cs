using RebeldeAlbertoMArtinez.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;
using RebeldeAlbertoMArtinez.Services.Log;
using RebeldeAlbertoMArtinez.Services.RebeldeFactory;

namespace RebeldeAlbertoMArtinez.Services.Repository
{
    public class Repositorio : IRebeldeRepository
    {
        private IRebeldeFactory Factory { get; set; }
        public IEnumerable<Rebelde> ListaRebeldes => throw new NotImplementedException();
        private readonly ILog writeLog;

        void IRebeldeRepository.Create(StringCollection collection)
        {
            
            try
            {
                var result = string.Empty;
                var obj = Factory.Create(collection);
                var listExistente = this.ListaRebeldes.ToList();
                listExistente.Add(obj);
                result = listExistente.ToString();
                writeLog.EscribirLog(result);
            }
            catch (Exception e)
            {
                throw new RebeldeRepositoryException("No ha sido posible crear los rebeldes.", e);
            }
        }
    }
}
