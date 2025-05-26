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
    public partial class CProvincia
    {
        
        [DataMember()]
        public Int32 ProvinciaID {get;set;}
        
        [DataMember()]
        public Int32 DepartamentoID {get;set;}
        
        [DataMember()]
        public String Nombre {get;set;}
        
        #region Constructores
        // Constructores
        public CProvincia()
        {
        }
        
        public CProvincia(Int32 ProvinciaID_, Int32 DepartamentoID_, String Nombre_)
        {
            ProvinciaID = ProvinciaID_;
            DepartamentoID = DepartamentoID_;
            Nombre = Nombre_;
        }
        #endregion
    }
}
