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
    public class FakeRepository : IRebeldeRepository
    {
        private IRebeldeFactory Factory { get; set; }
        private readonly ILog writeLog;

        public IEnumerable<Rebelde> ListaRebeldes { get; }  = new List<Rebelde>
        {
            new Rebelde("ALberto", "PLuton"),
            new Rebelde("Pepe", "Saturno"),
            new Rebelde("Juanito", "Marte"),
        };

        public void Create(StringCollection collection)
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
