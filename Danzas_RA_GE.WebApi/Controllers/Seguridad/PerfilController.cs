//------------------------------------------------------------------------------
// <Auto Generado: BSClassGenerator V2.0>
//     Generado por BRAIN SYSTEMS S.R.L.
//     Fecha: martes, 27 de agosto de 2024
// </Auto Generado>
//------------------------------------------------------------------------------
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects.Seguridad;
using Danzas_RA_GE.Facade.Seguridad;

namespace SisAutoBalWebApi.Controllers.Seguridad
{
    
    
    [Route("api/Perfil")]
    [ApiController()]
    public partial class PerfilController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CPerfil oTPerfil)
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                bool result = faTPerfil.Grabar(oTPerfil);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faTPerfil.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{IDPerfil}")]
        [HttpGet()]
        public virtual int Eliminar(Int32 IDPerfil)
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                return faTPerfil.Eliminar(IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{IDPerfil}")]
        [HttpGet()]
        public virtual CPerfil Recuperar(Int32 IDPerfil)
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                return faTPerfil.Recuperar(IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{IDPerfil}")]
        [HttpGet()]
        public virtual bool Existe(Int32 IDPerfil)
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                return faTPerfil.Existe(IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar/{IDPerfil}/{Des_Perfil}/{Estado}")]
        [HttpGet()]
        public virtual IList<CPerfil> Listar(String IDPerfil, String Des_Perfil, String Estado)
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                return faTPerfil.Listar(IDPerfil == "*" ? "" : IDPerfil, Des_Perfil == "*" ? "":Des_Perfil,Estado);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        [Route("LastIdentityValue")]
        [HttpGet()]
        public virtual int LastIdentityValue()
        {
            try
            {
                PerfilFacade faTPerfil = new PerfilFacade();
                return faTPerfil.LastIdentityValue();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
