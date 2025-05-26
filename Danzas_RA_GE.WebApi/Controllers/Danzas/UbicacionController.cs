





using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Danzas_RA_GE.Facade.Danzas;

namespace Danzas_RA_GE.WebApi.Controllers.Danzas
{
    
    
    [Route("api/Ubicacion")]
    [ApiController()]
    public partial class UbicacionController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CUbicacion oUbicacion)
        {
            try
            {
                UbicacionFacade faUbicacion = new UbicacionFacade();
                bool result = faUbicacion.Grabar(oUbicacion);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faUbicacion.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{UbicacionID}")]
        [HttpGet()]
        public virtual int Eliminar(String UbicacionID)
        {
            try
            {
                UbicacionFacade faUbicacion = new UbicacionFacade();
                return faUbicacion.Eliminar(UbicacionID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{UbicacionID}")]
        [HttpGet()]
        public virtual CUbicacion Recuperar(String UbicacionID)
        {
            try
            {
                UbicacionFacade faUbicacion = new UbicacionFacade();
                return faUbicacion.Recuperar(UbicacionID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{UbicacionID}")]
        [HttpGet()]
        public virtual bool Existe(String UbicacionID)
        {
            try
            {
                UbicacionFacade faUbicacion = new UbicacionFacade();
                return faUbicacion.Existe(UbicacionID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar")]
        [HttpGet()]
        public virtual IList<CUbicacion> Listar()
        {
            try
            {
                UbicacionFacade faUbicacion = new UbicacionFacade();
                return faUbicacion.Listar();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
