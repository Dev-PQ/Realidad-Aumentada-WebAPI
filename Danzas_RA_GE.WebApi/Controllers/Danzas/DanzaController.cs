





using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Danzas_RA_GE.Facade.Danzas;

namespace Danzas_RA_GE.WebApi.Controllers.Danzas
{
    
    
    [Route("api/Danza")]
    [ApiController()]
    public partial class DanzaController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CDanza oDanza)
        {
            try
            {
                DanzaFacade faDanza = new DanzaFacade();
                bool result = faDanza.Grabar(oDanza);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faDanza.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{DanzaID}")]
        [HttpGet()]
        public virtual int Eliminar(String DanzaID)
        {
            try
            {
                DanzaFacade faDanza = new DanzaFacade();
                return faDanza.Eliminar(DanzaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{DanzaID}")]
        [HttpGet()]
        public virtual CDanza Recuperar(String DanzaID)
        {
            try
            {
                DanzaFacade faDanza = new DanzaFacade();
                return faDanza.Recuperar(DanzaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{DanzaID}")]
        [HttpGet()]
        public virtual bool Existe(String DanzaID)
        {
            try
            {
                DanzaFacade faDanza = new DanzaFacade();
                return faDanza.Existe(DanzaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar")]
        [HttpGet()]
        public virtual IList<CDanza> Listar()
        {
            try
            {
                DanzaFacade faDanza = new DanzaFacade();
                return faDanza.Listar();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
