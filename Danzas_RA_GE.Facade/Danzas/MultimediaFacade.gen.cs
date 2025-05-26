





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
    public partial class MultimediaFacade
    {
        
        private MultimediaDao multimedia;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public MultimediaFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: multimedia = new MultimediaDao();
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
        public virtual bool Grabar(CMultimedia oMultimedia)
        {
            Error = "";
            hayError = false;
            DanzaFacade faDanza = new DanzaFacade();
            //---Validando campos no nulos
            if (oMultimedia.MultimediaID<=0)
            {
            	Error = "MultimediaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oMultimedia.DanzaID.Trim() == "")
            {
            	Error = "DanzaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oMultimedia.Tipo.Trim() == "")
            {
            	Error = "Tipo no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else if (!faDanza.Existe(oMultimedia.DanzaID))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oMultimedia.DanzaID," en DanzaID no existe. (Danza, DanzaID)");
            	hayError = true;
            	return false;
            }
            else
            	return multimedia.Grabar(oMultimedia);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CMultimedia oMultimedia, out string error)
        {
            bool rpta = Grabar(oMultimedia);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(Int32 MultimediaID)
        {
            return multimedia.Eliminar(MultimediaID);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CMultimedia Recuperar(Int32 MultimediaID)
        {
            return multimedia.Recuperar(MultimediaID);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(Int32 MultimediaID)
        {
            return multimedia.Existe(MultimediaID);
        }
        
        public virtual bool Existe(Int32 MultimediaID, out CMultimedia oMultimedia)
        {
            return multimedia.Existe(MultimediaID, out oMultimedia);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CMultimedia> Listar()
        {
            return multimedia.Listar();
        }
        #endregion
    }
}
