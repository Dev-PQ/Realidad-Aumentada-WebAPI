//------------------------------------------------------------------------------
// <Auto Generado: BSClassGenerator V2.0>
//     Generado por BRAIN SYSTEMS S.R.L.
//     Fecha: domingo, 27 de abril de 2025
// </Auto Generado>
//------------------------------------------------------------------------------
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriaNetCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Danzas_RA_GE.BusinessObjects;
using Danzas_RA_GE.Facade;
using Danzas_RA_GE.BusinessObjects.Configuracion;
using System.Drawing;

namespace Danzas_RA_GEWebApi.Controllers.Configuracion
{
    
    
    [Route("api/configuracionesSistema")]
    [ApiController()]
    public partial class ConfiguracionesSistemaController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(ConfiguracionesSistema oconfiguracionesSistema)
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                bool result = faconfiguracionesSistema.Grabar(oconfiguracionesSistema);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faconfiguracionesSistema.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{Id}")]
        [HttpGet()]
        public virtual int Eliminar(Int32 Id)
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                return faconfiguracionesSistema.Eliminar(Id);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{Id}")]
        [HttpGet()]
        public virtual ConfiguracionesSistema Recuperar(Int32 Id)
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                return faconfiguracionesSistema.Recuperar(Id);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{Id}")]
        [HttpGet()]
        public virtual bool Existe(Int32 Id)
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                return faconfiguracionesSistema.Existe(Id);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar/{ID}/{Clave}/{Valor}/{Descripcion}")]
        [HttpGet()]
        public virtual IList<ConfiguracionesSistema> Listar(Int32 ID, String Clave, String Valor,String Descripcion)
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                return faconfiguracionesSistema.Listar(ID,  Clave,  Valor,Descripcion);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }

        [Route("UltimoID")]
        [HttpGet()]
        public virtual int UltimoID()
        {
            try
            {
                ConfiguracionesSistemaFacade faconfiguracionesSistema = new ConfiguracionesSistemaFacade();
                return faconfiguracionesSistema.UltimoID();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
