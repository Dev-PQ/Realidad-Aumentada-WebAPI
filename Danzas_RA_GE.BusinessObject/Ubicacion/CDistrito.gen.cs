//------------------------------------------------------------------------------
// <Auto Generado: BSClassGenerator V2.0>
//     Generado por BRAIN SYSTEMS S.R.L.
//     Fecha: martes, 13 de mayo de 2025
// </Auto Generado>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects
{
    
    
    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CDistrito
    {
        
        [DataMember()]
        public Int32 DistritoID {get;set;}
        
        [DataMember()]
        public Int32 ProvinciaID {get;set;}
        
        [DataMember()]
        public String Nombre {get;set;}
        
        #region Constructores
        // Constructores
        public CDistrito()
        {
        }
        
        public CDistrito(Int32 DistritoID_, Int32 ProvinciaID_, String Nombre_)
        {
            DistritoID = DistritoID_;
            ProvinciaID = ProvinciaID_;
            Nombre = Nombre_;
        }
        #endregion
    }
}
