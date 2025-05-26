using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Danzas_RA_GE.BusinessObjects.Seguridad
{
    public partial class CAccesoMenuP
    {
        [DataMember()]
        public Int32 IDPerfil { get; set; }
        [DataMember()]
        public String Cod_Acceso { get; set; }

        [DataMember()]
        public String Nombre_Acceso { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        [DataMember()]
        public String Comando { get; set; }

        [DataMember()]
        public Int16 Nivel { get; set; }

        [DataMember()]
        public Char Estado { get; set; }

        [DataMember()]
        public String Cod_Sistema { get; set; }

        #region Constructores
        // Constructores
        public CAccesoMenuP()
        {
        }

        public CAccesoMenuP(Int32 IDPerfil_ ,String Cod_Acceso_, String Nombre_Acceso_, String Descripcion_, String Comando_, Int16 Nivel_, Char Estado_, string Cod_Sistema_)
        {
            IDPerfil = IDPerfil_;
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
