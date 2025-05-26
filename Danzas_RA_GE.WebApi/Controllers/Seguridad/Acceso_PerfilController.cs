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

namespace Danzas_RA_GE.WebApi.Controllers.Seguridad
{
    
    
    [Route("api/Acceso_Perfil")]
    [ApiController()]
    public partial class Acceso_PerfilController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CAcceso_Perfil oTAcceso_Perfil)
        {
            try
            {
                Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                bool result = faTAcceso_Perfil.Grabar(oTAcceso_Perfil);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faTAcceso_Perfil.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{Cod_Acceso}/{IDPerfil}")]
        [HttpGet()]
        public virtual int Eliminar(String Cod_Acceso, Int32 IDPerfil)
        {
            try
            {
                Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                return faTAcceso_Perfil.Eliminar(Cod_Acceso,IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{Cod_Acceso}/{IDPerfil}")]
        [HttpGet()]
        public virtual CAcceso_Perfil Recuperar(String Cod_Acceso, Int32 IDPerfil)
        {
            try
            {
                Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                return faTAcceso_Perfil.Recuperar(Cod_Acceso,IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{Cod_Acceso}/{IDPerfil}")]
        [HttpGet()]
        public virtual bool Existe(String Cod_Acceso, Int32 IDPerfil)
        {
            try
            {
                Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                return faTAcceso_Perfil.Existe(Cod_Acceso,IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar")]
        [HttpGet()]
        public virtual IList<CAcceso_Perfil> Listar()
        {
            try
            {
                Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                return faTAcceso_Perfil.Listar();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
