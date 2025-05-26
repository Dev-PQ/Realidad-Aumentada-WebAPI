using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Danzas
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CDanza
    {
        
        [DataMember()]
        public String DanzaID {get;set;}
        
        [DataMember()]
        public String Nombre {get;set;}
        
        [DataMember()]
        public String Descripcion {get;set;}
        
        [DataMember()]
        public String Historia {get;set;}
        
        [DataMember()]
        public String CategoriaID {get;set;}
        
        #region Constructores
        // Constructores
        public CDanza()
        {
        }
        
        public CDanza(String DanzaID_, String Nombre_, String Descripcion_, String Historia_, String CategoriaID_)
        {
            DanzaID = DanzaID_;
            Nombre = Nombre_;
            Descripcion = Descripcion_;
            Historia = Historia_;
            CategoriaID = CategoriaID_;
        }
        #endregion
    }
}
