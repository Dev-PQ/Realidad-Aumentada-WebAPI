using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzas_RA_GE.BusinessObjects.Seguridad
{
    public partial class CLogin
    {
        public String Usuario { get; set; }
        public String Password { get; set; }

        public CLogin() { }

        public CLogin(String usuario, String password)
        {
            Usuario = usuario;
            Password = password;
        }
    }
}
