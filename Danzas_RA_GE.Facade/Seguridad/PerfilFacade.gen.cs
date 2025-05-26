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
    public partial class PerfilFacade
    {
        
        private PerfilDao tPerfil;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public PerfilFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: tPerfil = new PerfilDao();
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
        public virtual bool Grabar(CPerfil oTPerfil)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oTPerfil.IDPerfil<=0)
            {
            	Error = "IDPerfil no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else
            	return tPerfil.Grabar(oTPerfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CPerfil oTPerfil, out string error)
        {
            bool rpta = Grabar(oTPerfil);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(Int32 IDPerfil)
        {
            return tPerfil.Eliminar(IDPerfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CPerfil Recuperar(Int32 IDPerfil)
        {
            return tPerfil.Recuperar(IDPerfil);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(Int32 IDPerfil)
        {
            return tPerfil.Existe(IDPerfil);
        }
        
        public virtual bool Existe(Int32 IDPerfil, out CPerfil oTPerfil)
        {
            return tPerfil.Existe(IDPerfil, out oTPerfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CPerfil> Listar(String IDPerfil, String Des_Perfil, String Estado)
        {
            return tPerfil.Listar( IDPerfil, Des_Perfil, Estado);
        }

        public virtual int LastIdentityValue()
        {
            return tPerfil.LastIdentityValue();
        }
        #endregion
    }
}
