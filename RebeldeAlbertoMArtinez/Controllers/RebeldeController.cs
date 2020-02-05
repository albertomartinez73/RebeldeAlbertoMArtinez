using System;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;
using RebeldeAlbertoMArtinez.Services.Log;
using RebeldeAlbertoMArtinez.Services.Repository;

namespace RebeldeAlbertoMArtinez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebeldeController : ControllerBase
    {
        private readonly IRebeldeRepository _repository;
        private readonly ILog _writeLog;
        public RebeldeController(IRebeldeRepository repository, ILog writeLog)
        {
            this._repository = repository;
            this._writeLog = writeLog;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string result = String.Empty;
                var listObjects = _repository.ListaRebeldes.ToList();

                foreach (var item in listObjects)
                {
                    result = $" Leído correctamente el Rebelde con el Nombre ->  {item.Nombre}, del Planeta ->  {item.Planeta}";
                    _writeLog.EscribirLog(result);
                }
                return Ok(listObjects);

            }
            catch (ExceptionControllerGet e)
            {
                _writeLog.EscribirLog(e.Message);
                throw new ExceptionControllerGet("Fallo RebeldeController metodo get", e);
            }
            
        }

        //POST api/values
        [HttpPost("/api/rebelde/post")]
        public IActionResult Post(StringCollection collection)
        {
            try
            {
                _repository.Create(collection);
                this._writeLog.EscribirLog("Rebelde creado correctamente.");
                return Ok();
            }
            catch (ExceptionControllerCreate e)
            {
                _writeLog.EscribirLog(e.Message);
                throw new ExceptionControllerCreate("Fallo RebeldeController metodo create", e);
            } 
            
        }
    }
}