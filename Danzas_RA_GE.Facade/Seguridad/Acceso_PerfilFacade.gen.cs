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
    public partial class Acceso_PerfilFacade
    {
        
        private Acceso_PerfilDao acceso_Perfil;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public Acceso_PerfilFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: acceso_Perfil = new Acceso_PerfilDao();
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
        public virtual bool Grabar(CAcceso_Perfil oTAcceso_Perfil)
        {
            Error = "";
            hayError = false;
            AccesoFacade faAcceso = new AccesoFacade();
            PerfilFacade faPerfil = new PerfilFacade();
            //---Validando campos no nulos
            if (oTAcceso_Perfil.Cod_Acceso.Trim() == "")
            {
            	Error = "Cod_Acceso no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oTAcceso_Perfil.IDPerfil<=0)
            {
            	Error = "IDPerfil no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else if (!faAcceso.Existe(oTAcceso_Perfil.Cod_Acceso))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTAcceso_Perfil.Cod_Acceso," en Cod_Acceso no existe. (TAcceso, Cod_Acceso)");
            	hayError = true;
            	return false;
            }
            else if (!faAcceso.Existe(oTAcceso_Perfil.Cod_Acceso))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTAcceso_Perfil.Cod_Acceso," en Cod_Acceso no existe. (TAcceso, Cod_Acceso)");
            	hayError = true;
            	return false;
            }
            else if (!faPerfil.Existe(oTAcceso_Perfil.IDPerfil))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTAcceso_Perfil.IDPerfil," en IDPerfil no existe. (TPerfil, IDPerfil)");
            	hayError = true;
            	return false;
            }
            else if (!faAcceso.Existe(oTAcceso_Perfil.Cod_Acceso))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTAcceso_Perfil.Cod_Acceso," en Cod_Acceso no existe. (TAcceso, Cod_Acceso)");
            	hayError = true;
            	return false;
            }
            else if (!faPerfil.Existe(oTAcceso_Perfil.IDPerfil))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oTAcceso_Perfil.IDPerfil," en IDPerfil no existe. (TPerfil, IDPerfil)");
            	hayError = true;
            	return false;
            }
            else
            	return acceso_Perfil.Grabar(oTAcceso_Perfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CAcceso_Perfil oTAcceso_Perfil, out string error)
        {
            bool rpta = Grabar(oTAcceso_Perfil);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String Cod_Acceso, Int32 IDPerfil)
        {
            return acceso_Perfil.Eliminar(Cod_Acceso,IDPerfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CAcceso_Perfil Recuperar(String Cod_Acceso, Int32 IDPerfil)
        {
            return acceso_Perfil.Recuperar(Cod_Acceso,IDPerfil);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String Cod_Acceso, Int32 IDPerfil)
        {
            return acceso_Perfil.Existe(Cod_Acceso,IDPerfil);
        }
        
        public virtual bool Existe(String Cod_Acceso, Int32 IDPerfil, out CAcceso_Perfil oTAcceso_Perfil)
        {
            return acceso_Perfil.Existe(Cod_Acceso,IDPerfil, out oTAcceso_Perfil);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CAcceso_Perfil> Listar()
        {
            return acceso_Perfil.Listar();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CAcceso_Perfil> ListarXPerfil(int IDPerfil)
        {
            return acceso_Perfil.ListarXPerfil(IDPerfil);
        }
        #endregion
    }
}
