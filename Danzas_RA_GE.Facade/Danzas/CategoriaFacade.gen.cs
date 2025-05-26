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
    public partial class CategoriaFacade
    {
        
        private CategoriaDao categoria;
        
        // --- Variables de control de errores 
        private string Error;
        
        private bool hayError;
        
        #region Constructores
        public CategoriaFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default: categoria = new CategoriaDao();
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
        public virtual bool Grabar(CCategoria oCategoria)
        {
            Error = "";
            hayError = false;
            //---Validando campos no nulos
            if (oCategoria.CategoriaID.Trim() == "")
            {
            	Error = "CategoriaID no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            else if (oCategoria.Nombre.Trim() == "")
            {
            	Error = "Nombre no puede ser vacío.";
            	hayError = true;
            	return false;
            }
            //---Validando referencias foraneas
            else
            	return categoria.Grabar(oCategoria);
        }
        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public virtual bool Grabar(CCategoria oCategoria, out string error)
        {
            bool rpta = Grabar(oCategoria);
            error = Error;
            return rpta;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public virtual int Eliminar(String CategoriaID)
        {
            return categoria.Eliminar(CategoriaID);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual CCategoria Recuperar(String CategoriaID)
        {
            return categoria.Recuperar(CategoriaID);
        }
        #endregion
        
        #region Metodos Secundarios
        public virtual bool Existe(String CategoriaID)
        {
            return categoria.Existe(CategoriaID);
        }
        
        public virtual bool Existe(String CategoriaID, out CCategoria oCategoria)
        {
            return categoria.Existe(CategoriaID, out oCategoria);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public virtual IList<CCategoria> Listar()
        {
            return categoria.Listar();
        }
        #endregion
    }
}
