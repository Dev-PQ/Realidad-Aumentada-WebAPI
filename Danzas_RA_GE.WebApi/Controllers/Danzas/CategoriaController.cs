using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Danzas_RA_GE.Facade.Danzas;

namespace Danzas_RA_GE.WebApi.Controllers.Danzas
{
    
    
    [Route("api/Categoria")]
    [ApiController()]
    public partial class CategoriaController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CCategoria oCategoria)
        {
            try
            {
                CategoriaFacade faCategoria = new CategoriaFacade();
                bool result = faCategoria.Grabar(oCategoria);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faCategoria.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{CategoriaID}")]
        [HttpGet()]
        public virtual int Eliminar(String CategoriaID)
        {
            try
            {
                CategoriaFacade faCategoria = new CategoriaFacade();
                return faCategoria.Eliminar(CategoriaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{CategoriaID}")]
        [HttpGet()]
        public virtual CCategoria Recuperar(String CategoriaID)
        {
            try
            {
                CategoriaFacade faCategoria = new CategoriaFacade();
                return faCategoria.Recuperar(CategoriaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{CategoriaID}")]
        [HttpGet()]
        public virtual bool Existe(String CategoriaID)
        {
            try
            {
                CategoriaFacade faCategoria = new CategoriaFacade();
                return faCategoria.Existe(CategoriaID);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar")]
        [HttpGet()]
        public virtual IList<CCategoria> Listar()
        {
            try
            {
                CategoriaFacade faCategoria = new CategoriaFacade();
                return faCategoria.Listar();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
