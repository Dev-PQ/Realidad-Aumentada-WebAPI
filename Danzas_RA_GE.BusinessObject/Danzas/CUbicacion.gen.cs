





using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Danzas
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CUbicacion
    {
        
        [DataMember()]
        public String UbicacionID {get;set;}
        
        [DataMember()]
        public String DanzaID {get;set;}
        
        [DataMember()]
        public Decimal Latitud {get;set;}
        
        [DataMember()]
        public Decimal Longitud {get;set;}
        
        [DataMember()]
        public String Direccion {get;set;}
        
        #region Constructores
        // Constructores
        public CUbicacion()
        {
        }
        
        public CUbicacion(String UbicacionID_, String DanzaID_, Decimal Latitud_, Decimal Longitud_, String Direccion_)
        {
            UbicacionID = UbicacionID_;
            DanzaID = DanzaID_;
            Latitud = Latitud_;
            Longitud = Longitud_;
            Direccion = Direccion_;
        }
        #endregion
    }
}
