using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace Danzas_RA_GE.BusinessObjects.Seguridad
{
    
    
    // Propiedades AutoImplementadas
    public partial class CPerfil
    {
        
        [DataMember()]
        public Int32 IDPerfil {get;set;}
        
        [DataMember()]
        public String Des_Perfil {get;set;}
        
        [DataMember()]
        public Char Estado {get;set;}
        
        #region Constructores
        // Constructores
        public CPerfil()
        {
        }
        
        public CPerfil(Int32 IDPerfil_, String Des_Perfil_, Char Estado_)
        {
            IDPerfil = IDPerfil_;
            Des_Perfil = Des_Perfil_;
            Estado = Estado_;
        }
        #endregion
    }
}
