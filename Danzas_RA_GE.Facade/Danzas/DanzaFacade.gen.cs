





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
    public partial class DanzaFacade
    {
        
        private DanzaDao danza;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public DanzaFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
            default: danza = new DanzaDao();
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
        public virtual bool Grabar(CDanza oDanza)
        {
            Error = "";
            hayError = false;
            CategoriaFacade faCategoria = new CategoriaFacade();
            //---Validando campos no nulos
            if (oDanza.DanzaID.Trim() == "")
            {
            	Error = "DanzaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oDanza.Nombre.Trim() == "")
            {
            	Error = "Nombre no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oDanza.CategoriaID.Trim() == "")
            {
            	Error = "CategoriaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else if (!faCategoria.Existe(oDanza.CategoriaID))
            {//---No existe clave foranea pero permite vacio
            	Error = string.Concat("El valor ", oDanza.CategoriaID," en CategoriaID no existe. (Categoria, CategoriaID)");
            	hayError = true;
            	return false;
            }
            else
            	return danza.Grabar(oDanza);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CDanza oDanza, out string error)
        {
            bool rpta = Grabar(oDanza);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String DanzaID)
        {
            return danza.Eliminar(DanzaID);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CDanza Recuperar(String DanzaID)
        {
            return danza.Recuperar(DanzaID);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String DanzaID)
        {
            return danza.Existe(DanzaID);
        }
        
        public virtual bool Existe(String DanzaID, out CDanza oDanza)
        {
            return danza.Existe(DanzaID, out oDanza);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CDanza> Listar()
        {
            return danza.Listar();
        }
        #endregion
    }
}
