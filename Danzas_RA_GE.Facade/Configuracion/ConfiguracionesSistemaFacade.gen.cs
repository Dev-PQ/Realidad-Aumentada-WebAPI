using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using LibreriaNet.InfoApp;
using Danzas_RA_GE.BusinessObjects.Configuracion;
using Danzas_RA_GE.DataObjects;

namespace Danzas_RA_GE.Facade
{
    
    
    [DataObject(true)]
    public partial class ConfiguracionesSistemaFacade
    {
        
        private ConfiguracionesSistemaDao configuracionesSistema;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public ConfiguracionesSistemaFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: configuracionesSistema = new ConfiguracionesSistemaDao();
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
        public virtual bool Grabar(ConfiguracionesSistema oconfiguracionesSistema)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oconfiguracionesSistema.Id<=0)
            {
            	Error = "Id no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oconfiguracionesSistema.Clave.Trim() == "")
            {
            	Error = "Clave no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oconfiguracionesSistema.Valor.Trim() == "")
            {
            	Error = "Valor no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else
            	return configuracionesSistema.Grabar(oconfiguracionesSistema);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(ConfiguracionesSistema oconfiguracionesSistema, out string error)
        {
            bool rpta = Grabar(oconfiguracionesSistema);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(Int32 Id)
        {
            return configuracionesSistema.Eliminar(Id);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual ConfiguracionesSistema Recuperar(Int32 Id)
        {
            return configuracionesSistema.Recuperar(Id);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(Int32 Id)
        {
            return configuracionesSistema.Existe(Id);
        }
        
        public virtual bool Existe(Int32 Id, out ConfiguracionesSistema oconfiguracionesSistema)
        {
            return configuracionesSistema.Existe(Id, out oconfiguracionesSistema);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<ConfiguracionesSistema> Listar(Int32 ID, String Clave, String Valor,String Descripcion)
        {
            return configuracionesSistema.Listar(ID, Clave,Valor, Descripcion);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual int UltimoID()
        {
            return configuracionesSistema.UltimoID();
        }
        #endregion
    }
}
