





using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Danzas
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CMultimedia
    {
        
        [DataMember()]
        public Int32 MultimediaID {get;set;}
        
        [DataMember()]
        public String DanzaID {get;set;}
        
        [DataMember()]
        public String Tipo {get;set;}
        
        [DataMember()]
        public String URL {get;set;}
        
        [DataMember()]
        public Boolean BinArchivoDanza {get;set;}
        
        [DataMember()]
        public String Descripcion {get;set;}
        
        #region Constructores
        // Constructores
        public CMultimedia()
        {
        }
        
        public CMultimedia(Int32 MultimediaID_, String DanzaID_, String Tipo_, String URL_, Boolean BinArchivoDanza_, String Descripcion_)
        {
            MultimediaID = MultimediaID_;
            DanzaID = DanzaID_;
            Tipo = Tipo_;
            URL = URL_;
            BinArchivoDanza = BinArchivoDanza_;
            Descripcion = Descripcion_;
        }
        #endregion
    }
}
