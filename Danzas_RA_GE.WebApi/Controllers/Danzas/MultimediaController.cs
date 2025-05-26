





using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Danzas_RA_GE.Facade.Danzas;

namespace Danzas_RA_GE.WebApi.Controllers.Danzas
{
    
    
    [Route("api/Multimedia")]
    [ApiController()]
    public partial class MultimediaController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CMultimedia oMultimedia)
        {
            try
            {
                MultimediaFacade faMultimedia = new MultimediaFacade();
                bool result = faMultimedia.Grabar(oMultimedia);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faMultimedia.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{MultimediaID}")]
        [HttpGet()]
        public virtual int Eliminar(Int32 MultimediaID)
        {
            try
            {
                MultimediaFacade faMultimedia = new MultimediaFacade();
                return faMultimedia.Eliminar(MultimediaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{MultimediaID}")]
        [HttpGet()]
        public virtual CMultimedia Recuperar(Int32 MultimediaID)
        {
            try
            {
                MultimediaFacade faMultimedia = new MultimediaFacade();
                return faMultimedia.Recuperar(MultimediaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{MultimediaID}")]
        [HttpGet()]
        public virtual bool Existe(Int32 MultimediaID)
        {
            try
            {
                MultimediaFacade faMultimedia = new MultimediaFacade();
                return faMultimedia.Existe(MultimediaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar")]
        [HttpGet()]
        public virtual IList<CMultimedia> Listar()
        {
            try
            {
                MultimediaFacade faMultimedia = new MultimediaFacade();
                return faMultimedia.Listar();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
