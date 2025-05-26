using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Danzas
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CCategoria
    {
        
        [DataMember()]
        public String CategoriaID {get;set;}
        
        [DataMember()]
        public String Nombre {get;set;}
        
        [DataMember()]
        public String Descripcion {get;set;}
        
        #region Constructores
        // Constructores
        public CCategoria()
        {
        }
        
        public CCategoria(String CategoriaID_, String Nombre_, String Descripcion_)
        {
            CategoriaID = CategoriaID_;
            Nombre = Nombre_;
            Descripcion = Descripcion_;
        }
        #endregion
    }
}
