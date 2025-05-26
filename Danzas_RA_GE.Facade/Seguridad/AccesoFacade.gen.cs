//------------------------------------------------------------------------------
// <Auto Generado: BSClassGenerator V2.0>
//     Generado por BRAIN SYSTEMS S.R.L.
//     Fecha: martes, 27 de agosto de 2024
// </Auto Generado>
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using LibreriaNet.InfoApp;
using Danzas_RA_GE.BusinessObjects.Seguridad;
using Danzas_RA_GE.DataObjects.Seguridad;

namespace Danzas_RA_GE.Facade.Seguridad
{
    
    
    [DataObject(true)]
    public partial class AccesoFacade
    {
        
        private AccesoDao tAcceso;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public AccesoFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: tAcceso = new AccesoDao();
            break;
            }
        }
        #endregion
        
        #region Metodos de Control de Errores
        public virtual string getError()
        {
            return Error;
        }
        
        public virtual bool HayError()
        {
            return hayError;
        }
        #endregion
        
        #region Metodos Basicos
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CAcceso oTAcceso)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oTAcceso.Cod_Acceso.Trim() == "")
            {
            	Error = "Cod_Acceso no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else
            	return tAcceso.Grabar(oTAcceso);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CAcceso oTAcceso, out string error)
        {
            bool rpta = Grabar(oTAcceso);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String Cod_Acceso)
        {
            return tAcceso.Eliminar(Cod_Acceso);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CAcceso Recuperar(String Cod_Acceso)
        {
            return tAcceso.Recuperar(Cod_Acceso);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String Cod_Acceso)
        {
            return tAcceso.Existe(Cod_Acceso);
        }
        
        public virtual bool Existe(String Cod_Acceso, out CAcceso oTAcceso)
        {
            return tAcceso.Existe(Cod_Acceso, out oTAcceso);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CAcceso> Listar(String Cod_Acceso, String Nombre_Acceso, String Descripcion)
        {
            return tAcceso.Listar(Cod_Acceso, Nombre_Acceso, Descripcion);
        }
        public virtual IList<CAccesoMenuP> BuscarAcceso(int IDPerfil, String Cod_Sistema)
        {
            return tAcceso.BuscarAcceso(IDPerfil,Cod_Sistema);
        }
        
        public virtual IList<CAcceso> Menu(int IDPerfil)
        {
            return tAcceso.Menu(IDPerfil);
        }
        public virtual IList<CAcceso> AccesoNivelCero()
        {
            return tAcceso.AccesoNivelCero();
        }
        #endregion
    }
}
