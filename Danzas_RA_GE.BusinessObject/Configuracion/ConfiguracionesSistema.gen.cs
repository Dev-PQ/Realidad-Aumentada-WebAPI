
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Configuracion
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class ConfiguracionesSistema
    {
        
        [DataMember()]
        public Int32 Id {get;set;}
        
        [DataMember()]
        public String Clave {get;set;}
        
        [DataMember()]
        public String Valor {get;set;}
        
        [DataMember()]
        public String Descripcion {get;set;}
        
        [DataMember()]
        public DateTime FechaCreacion {get;set;}
        
        [DataMember()]
        public DateTime FechaModificacion {get;set;}
        
        #region Constructores
        // Constructores
        public ConfiguracionesSistema()
        {
        }
        
        public ConfiguracionesSistema(Int32 Id_, String Clave_, String Valor_, String Descripcion_, DateTime FechaCreacion_, DateTime FechaModificacion_)
        {
            Id = Id_;
            Clave = Clave_;
            Valor = Valor_;
            Descripcion = Descripcion_;
            FechaCreacion = FechaCreacion_;
            FechaModificacion = FechaModificacion_;
        }
        #endregion
    }
}
