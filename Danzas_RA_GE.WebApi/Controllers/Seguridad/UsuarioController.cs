using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Seguridad;
using Danzas_RA_GE.Facade.Seguridad;

namespace Danzas_RA_GE.WebApi.Controllers.Seguridad
{
    
    
    [Route("api/Usuario")]
    [ApiController()]
    public partial class UsuarioController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CUsuario oUsuario)
        {
            try
            {
                UsuarioFacade faTUsuario = new UsuarioFacade();
                bool result = faTUsuario.Grabar(oUsuario);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faTUsuario.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{CodUsuario}")]
        [HttpGet()]
        public virtual int Eliminar(String CodUsuario)
        {
            try
            {
                UsuarioFacade faTUsuario = new UsuarioFacade();
                return faTUsuario.Eliminar(CodUsuario);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{CodUsuario}")]
        [HttpGet()]
        public virtual CUsuario Recuperar(String CodUsuario)
        {
            try
            {
                UsuarioFacade faTUsuario = new UsuarioFacade();
                return faTUsuario.Recuperar(CodUsuario);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{CodUsuario}")]
        [HttpGet()]
        public virtual bool Existe(String CodUsuario)
        {
            try
            {
                UsuarioFacade faTUsuario = new UsuarioFacade();
                return faTUsuario.Existe(CodUsuario);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar/{CodUsuario}/{Nombre_Usuario}/{IDPerfil}")]
        [HttpGet()]
        public virtual IList<CUsuario> Listar(String CodUsuario, String Nombre_Usuario, String IDPerfil)
        {
            try
            {
                UsuarioFacade faTUsuario = new UsuarioFacade();
                return faTUsuario.Listar(CodUsuario, Nombre_Usuario, IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
