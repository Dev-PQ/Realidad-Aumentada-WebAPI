using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Seguridad;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Seguridad
{
    
    
    public partial class PerfilDao :  DataAccessBase
    {
        
        public virtual CPerfil getTPerfil(DataRow dr)
        {
            return new CPerfil(Convert.ToInt32(dr["IDPerfil"]),Convert.ToString(dr["Des_Perfil"]),Convert.ToChar(dr["Estado"]));
        }
        
        public virtual CPerfil getTPerfil(IDataReader dr)
        {
            return new CPerfil(Convert.ToInt32(dr["IDPerfil"]),Convert.ToString(dr["Des_Perfil"]),Convert.ToChar(dr["Estado"]));
        }
        
        #region Metodos Principales
        public virtual bool Grabar(CPerfil oTPerfil)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("TS_Perfil_I01")){
            Db.AddInParameter(dbCmd, "IDPerfil", DbType.Int32, oTPerfil.IDPerfil);
            Db.AddInParameter(dbCmd, "Des_Perfil", DbType.String, oTPerfil.Des_Perfil);
            Db.AddInParameter(dbCmd, "Estado", DbType.String, oTPerfil.Estado);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(Int32 IDPerfil)
        {
            return Db.ExecuteNonQuery("TPerfil_Eliminar",IDPerfil);
        }
        
        public virtual CPerfil Recuperar(Int32 IDPerfil)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Perfil_Q01", IDPerfil).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getTPerfil(dtDatos.Rows[0]);
            else
            return new CPerfil();
        }
        
        public virtual bool Existe(Int32 IDPerfil)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Perfil_Q01", IDPerfil).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(Int32 IDPerfil, out CPerfil oTPerfil)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Perfil_Q01", IDPerfil).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                oTPerfil = getTPerfil(dtDatos.Rows[0]);
                return true;
             }
            else
            {
                oTPerfil = new CPerfil();
                return false;
            }
        }
        
        public virtual IList<CPerfil> Listar(String IDPerfil, String Des_Perfil, String Estado)
        {
            // Validación de parámetros
            IDPerfil = string.IsNullOrWhiteSpace(IDPerfil) ? "*" : IDPerfil;
            Des_Perfil = string.IsNullOrWhiteSpace(Des_Perfil) ? "*" : Des_Perfil;
            Estado = string.IsNullOrWhiteSpace(Estado) ? "*" : Estado;
            DataTable dtDatos = Db.ExecuteDataSet("TS_Perfil_Q02", IDPerfil=="*"?DBNull.Value:Convert.ToInt16(IDPerfil), Des_Perfil=="*"?"":Des_Perfil,Estado).Tables[0];
            {
                IList<CPerfil> list = new List<CPerfil>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getTPerfil(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }
        public virtual int LastIdentityValue()
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Perfil_Q03").Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                return Convert.ToInt32(dtDatos.Rows[0]["LastIdentityValue"]); ;
            }
            else
            {
               
                return 0;
            }
        }
        #endregion
    }
}
