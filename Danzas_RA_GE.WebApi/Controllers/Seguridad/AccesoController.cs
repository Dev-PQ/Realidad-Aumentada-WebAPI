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
    
    
    [Route("api/Acceso")]
    [ApiController()]
    public partial class AccesoController : ControllerBase
    {
        
        [Route("Grabar")]
        [HttpPost()]
        public virtual ActionResult<System.Boolean> Grabar(CAcceso oAcceso)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                bool result = faTAcceso.Grabar(oAcceso);
                if (!result)
                {
                return StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new { message = faTAcceso.getError() }));
                }
                	return result;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Eliminar/{Cod_Acceso}")]
        [HttpGet()]
        public virtual int Eliminar(String Cod_Acceso)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.Eliminar(Cod_Acceso);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Recuperar/{Cod_Acceso}")]
        [HttpGet()]
        public virtual CAcceso Recuperar(String Cod_Acceso)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.Recuperar(Cod_Acceso);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Existe/{Cod_Acceso}")]
        [HttpGet()]
        public virtual bool Existe(String Cod_Acceso)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.Existe(Cod_Acceso);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Listar/{Cod_Acceso}/{Nombre_Acceso}/{Descripcion}")]
        [HttpGet()]
        public virtual IList<CAcceso> Listar(String Cod_Acceso, String Nombre_Acceso, String Descripcion)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.Listar(Cod_Acceso,Nombre_Acceso,Descripcion);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        [Route("BuscarAcceso/{IDPerfil}/{Cod_Sistema}")]
        [HttpGet()]
        public virtual IList<CAccesoMenuP> BuscarAcceso(int IDPerfil, String Cod_Sistema)
        {
            try
            {
                IList < CAccesoMenuP> accesoMenuP = new List<CAccesoMenuP>();
                AccesoFacade faTAcceso = new AccesoFacade();
                IList<CAcceso> accesos = faTAcceso.Listar("*", "*", "*");
                if (accesos.Count > 0)
                {
                    Acceso_PerfilFacade faTAcceso_Perfil = new Acceso_PerfilFacade();
                    IList<CAcceso_Perfil> acceso_Perfil = faTAcceso_Perfil.ListarXPerfil(IDPerfil);
                    if (accesos.Count > 0)
                    {
                        for (int i = 0; i < accesos.Count; i++)
                        {
                            int cont = 0;
                            CAccesoMenuP accesoMenu = new CAccesoMenuP();
                            for (int j = 0; j < acceso_Perfil.Count; j++)
                            {                                
                                if (accesos[i].Cod_Acceso == acceso_Perfil[j].Cod_Acceso)
                                {
                                    accesoMenu.IDPerfil = 1;
                                    cont = 1;
                                }
                                else
                                {
                                    if (cont == 0)
                                    {
                                        accesoMenu.IDPerfil = 0;
                                    }
                                }                         
                            }
                            accesoMenu.Cod_Acceso = accesos[i].Cod_Acceso;
                            accesoMenu.Nombre_Acceso = accesos[i].Nombre_Acceso;
                            accesoMenu.Descripcion = accesos[i].Descripcion;
                            accesoMenu.Comando = accesos[i].Comando;
                            accesoMenu.Nivel = accesos[i].Nivel;
                            accesoMenu.Estado = accesos[i].Estado;
                            accesoMenu.Cod_Sistema = accesos[i].Cod_Sistema;
                            accesoMenuP.Add(accesoMenu);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < accesos.Count; i++)
                        {
                            CAccesoMenuP accesoMenu = new CAccesoMenuP();
                            accesoMenu.IDPerfil = 0;
                            accesoMenu.Cod_Acceso = accesos[i].Cod_Acceso;
                            accesoMenu.Nombre_Acceso = accesos[i].Nombre_Acceso;
                            accesoMenu.Descripcion = accesos[i].Descripcion;
                            accesoMenu.Comando = accesos[i].Comando;
                            accesoMenu.Nivel = accesos[i].Nivel;
                            accesoMenu.Estado = accesos[i].Estado;
                            accesoMenu.Cod_Sistema = accesos[i].Cod_Sistema;
                            accesoMenuP.Add(accesoMenu);
                        }
                    }
                }
                return accesoMenuP;
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
        
        [Route("Menu/{IDPerfil}")]
        [HttpGet()]
        public virtual IList<CAcceso> Menu(int IDPerfil)
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.Menu(IDPerfil);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }

        [Route("AccesoNivelCero")]
        [HttpGet()]
        public virtual IList<CAcceso> AccesoNivelCero()
        {
            try
            {
                AccesoFacade faTAcceso = new AccesoFacade();
                return faTAcceso.AccesoNivelCero();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw e;
            }
        }
    }
}
