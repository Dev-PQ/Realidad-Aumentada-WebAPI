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
using Danzas_RA_GE.Facade.Seguridad;

namespace Danzas_RA_GE.Facade.Seguridad
{
    
    
    [DataObject(true)]
    public partial class UsuarioFacade
    {
        
        private UsuarioDao tUsuario;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public UsuarioFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: tUsuario = new UsuarioDao();
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
        public virtual bool Grabar(CUsuario oTUsuario)
        {
            Error = "";
            hayError = false;
            PerfilFacade faTPerfil = new PerfilFacade();
            //---Validando campos no nulos
            if (oTUsuario.CodUsuario.Trim() == "")
            {
            	Error = "CodUsuario no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else if ((oTUsuario.IDPerfil <= 0 && (!faTPerfil.Existe(oTUsuario.IDPerfil))))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTUsuario.IDPerfil," en IDPerfil no existe. (TPerfil, IDPerfil)");
            	hayError = true;
            	return false;
            }
            else
            	return tUsuario.Grabar(oTUsuario);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CUsuario oTUsuario, out string error)
        {
            bool rpta = Grabar(oTUsuario);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CodUsuario)
        {
            return tUsuario.Eliminar(CodUsuario);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CUsuario Recuperar(String CodUsuario)
        {
            return tUsuario.Recuperar(CodUsuario);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String CodUsuario)
        {
            return tUsuario.Existe(CodUsuario);
        }
        
        public virtual bool Existe(String CodUsuario, out CUsuario oTUsuario)
        {
            return tUsuario.Existe(CodUsuario, out oTUsuario);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CUsuario> Listar(String CodUsuario, String Nombre_Usuario, String IDPerfil)
        {
            return tUsuario.Listar(CodUsuario, Nombre_Usuario, IDPerfil);
        }
        #endregion
    }
}
