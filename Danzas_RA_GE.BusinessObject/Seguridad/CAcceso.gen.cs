using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Danzas_RA_GE.BusinessObjects.Seguridad
{
    
    
    // Propiedades AutoImplementadas
    public partial class CAcceso
    {
        
        [DataMember()]
        public String Cod_Acceso {get;set;}
        
        [DataMember()]
        public String Nombre_Acceso {get;set;}
        
        [DataMember()]
        public String Descripcion {get;set;}
        
        [DataMember()]
        public String Comando {get;set;}
        
        [DataMember()]
        public Int16 Nivel {get;set;}
        
        [DataMember()]
        public Char Estado {get;set;}

        [DataMember()]
        public String Cod_Sistema { get; set; }

        #region Constructores
        // Constructores
        public CAcceso()
        {
        }
        
        public CAcceso(String Cod_Acceso_, String Nombre_Acceso_, String Descripcion_, String Comando_, Int16 Nivel_, Char Estado_, string Cod_Sistema_)
        {
            Cod_Acceso = Cod_Acceso_;
            Nombre_Acceso = Nombre_Acceso_;
            Descripcion = Descripcion_;
            Comando = Comando_;
            Nivel = Nivel_;
            Estado = Estado_;
            Cod_Sistema = Cod_Sistema_;
        }
        #endregion
    }
}
