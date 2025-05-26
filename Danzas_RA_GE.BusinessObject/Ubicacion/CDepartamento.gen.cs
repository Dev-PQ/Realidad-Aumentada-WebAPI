using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Danzas_RA_GE.BusinessObjects.Ubicacion
{

    // Propiedades AutoImplementadas
    [DataContract()]
    [Serializable()]
    public partial class CDepartamento
    {
        
        [DataMember()]
        public Int32 DepartamentoID {get;set;}
        
        [DataMember()]
        public String Nombre {get;set;}
        
        #region Constructores
        // Constructores
        public CDepartamento()
        {
        }
        
        public CDepartamento(Int32 DepartamentoID_, String Nombre_)
        {
            DepartamentoID = DepartamentoID_;
            Nombre = Nombre_;
        }
        #endregion
    }
}
