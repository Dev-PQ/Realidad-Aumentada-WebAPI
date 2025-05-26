





using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using LibreriaNet.InfoApp;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Danzas_RA_GE.DataObjects.Danzas;

namespace Danzas_RA_GE.Facade.Danzas
{
    
    
    [DataObject(true)]
    public partial class UbicacionFacade
    {
        
        private UbicacionDao ubicacion;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public UbicacionFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: ubicacion = new UbicacionDao();
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
        public virtual bool Grabar(CUbicacion oUbicacion)
        {
            Error = "";
            hayError = false;
            DanzaFacade faDanza = new DanzaFacade();
            //---Validando campos no nulos
            if (oUbicacion.UbicacionID.Trim() == "")
            {
            	Error = "UbicacionID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oUbicacion.DanzaID.Trim() == "")
            {
            	Error = "DanzaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oUbicacion.Latitud<=0)
            {
            	Error = "Latitud no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oUbicacion.Longitud<=0)
            {
            	Error = "Longitud no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else if (!faDanza.Existe(oUbicacion.DanzaID))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oUbicacion.DanzaID," en DanzaID no existe. (Danza, DanzaID)");
            	hayError = true;
            	return false;
            }
            else
            	return ubicacion.Grabar(oUbicacion);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CUbicacion oUbicacion, out string error)
        {
            bool rpta = Grabar(oUbicacion);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String UbicacionID)
        {
            return ubicacion.Eliminar(UbicacionID);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CUbicacion Recuperar(String UbicacionID)
        {
            return ubicacion.Recuperar(UbicacionID);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String UbicacionID)
        {
            return ubicacion.Existe(UbicacionID);
        }
        
        public virtual bool Existe(String UbicacionID, out CUbicacion oUbicacion)
        {
            return ubicacion.Existe(UbicacionID, out oUbicacion);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CUbicacion> Listar()
        {
            return ubicacion.Listar();
        }
        #endregion
    }
}
