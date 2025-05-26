using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace Danzas_RA_GE.BusinessObjects.Seguridad
{
    
    
    // Propiedades AutoImplementadas
    public partial class CUsuario
    {
        
        [DataMember()]
        public String CodUsuario {get;set;}
        
        [DataMember()]
        public String Nombre_Usuario {get;set;}
        
        [DataMember()]
        public Boolean flagActDir {get;set;}
        
        [DataMember()]
        public String Passwd {get;set;}
        
        [DataMember()]
        public Char Estado {get;set;}
        
        [DataMember()]
        public Int32 IDPerfil {get;set;}
        
        [DataMember()]
        public String UserNew {get;set;}
        
        [DataMember()]
        public DateTime DateNew {get;set;}
        
        [DataMember()]
        public String UserEdit {get;set;}
        
        [DataMember()]
        public DateTime DateEdit {get;set;}
        
        [DataMember()]
        public String Mail {get;set;}
        
        #region Constructores
        // Constructores
        public CUsuario()
        {
        }
        
        public CUsuario(String CodUsuario_, String Nombre_Usuario_, Boolean flagActDir_, String Passwd_, Char Estado_, Int32 IDPerfil_, String UserNew_, DateTime DateNew_, String UserEdit_, DateTime DateEdit_, String Mail_)
        {
            CodUsuario = CodUsuario_;
            Nombre_Usuario = Nombre_Usuario_;
            flagActDir = flagActDir_;
            Passwd = Passwd_;
            Estado = Estado_;
            IDPerfil = IDPerfil_;
            UserNew = UserNew_;
            DateNew = DateNew_;
            UserEdit = UserEdit_;
            DateEdit = DateEdit_;
            Mail = Mail_;
        }
        #endregion
    }
}
