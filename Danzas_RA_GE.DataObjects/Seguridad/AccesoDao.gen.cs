using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Seguridad;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Seguridad
{
    
    
    public partial class AccesoDao : DataAccessBase
    {
        
        public virtual CAcceso getTAcceso(DataRow dr)
        {
            return new CAcceso(Convert.ToString(dr["Cod_Acceso"])!,Convert.ToString(dr["Nombre_Acceso"])!,Convert.ToString(dr["Descripcion"])!,Convert.ToString(dr["Comando"])!,Convert.ToInt16(dr["Nivel"]),Convert.ToChar(dr["Estado"]), Convert.ToString(dr["Cod_Sistema"])!);
        }
        
        public virtual CAcceso getTAcceso(IDataReader dr)
        {
            return new CAcceso(Convert.ToString(dr["Cod_Acceso"])!,Convert.ToString(dr["Nombre_Acceso"])!,Convert.ToString(dr["Descripcion"])!,Convert.ToString(dr["Comando"])!,Convert.ToInt16(dr["Nivel"]),Convert.ToChar(dr["Estado"]), Convert.ToString(dr["Cod_Sistema"])!);
        }
        public virtual CAccesoMenuP getTAccesoMenu(DataRow dr)
        {
            return new CAccesoMenuP(Convert.ToInt32(dr["IDPerfil"]), Convert.ToString(dr["Cod_Acceso"])!, Convert.ToString(dr["Nombre_Acceso"])!, Convert.ToString(dr["Descripcion"])!, Convert.ToString(dr["Comando"])!, Convert.ToInt16(dr["Nivel"]), Convert.ToChar(dr["Estado"]), Convert.ToString(dr["Cod_Sistema"])!);
        }

        #region Metodos Principales
        public virtual bool Grabar(CAcceso oTAcceso)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("TS_Acceso_I01")){
            Db.AddInParameter(dbCmd, "Cod_Acceso", DbType.String, oTAcceso.Cod_Acceso);
            Db.AddInParameter(dbCmd, "Nombre_Acceso", DbType.String, oTAcceso.Nombre_Acceso);
            Db.AddInParameter(dbCmd, "Descripcion", DbType.String, oTAcceso.Descripcion);
            Db.AddInParameter(dbCmd, "Comando", DbType.String, oTAcceso.Comando);
            Db.AddInParameter(dbCmd, "Nivel", DbType.Int16, oTAcceso.Nivel);
            Db.AddInParameter(dbCmd, "Estado", DbType.String, oTAcceso.Estado);
            Db.AddInParameter(dbCmd, "Cod_Sistema", DbType.String, oTAcceso.Cod_Sistema);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(String Cod_Acceso)
        {
            return Db.ExecuteNonQuery("TAcceso_Eliminar",Cod_Acceso);
        }
        
        public virtual CAcceso Recuperar(String Cod_Acceso)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q01", Cod_Acceso).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getTAcceso(dtDatos.Rows[0]);
            else
            return new CAcceso();
        }
        
        public virtual bool Existe(String Cod_Acceso)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q01", Cod_Acceso).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(String Cod_Acceso, out CAcceso oTAcceso)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q01", Cod_Acceso).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oTAcceso = getTAcceso(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oTAcceso = new CAcceso();
            return false;
            }
        }
        
        public virtual IList<CAcceso> Listar(String Cod_Acceso, String Nombre_Acceso, String Descripcion)
        {
            // Validación de parámetros
            Cod_Acceso = string.IsNullOrWhiteSpace(Cod_Acceso) ? "*" : Cod_Acceso;
            Nombre_Acceso = string.IsNullOrWhiteSpace(Nombre_Acceso) ? "*" : Nombre_Acceso;
            Descripcion = string.IsNullOrWhiteSpace(Descripcion) ? "*" : Descripcion;
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q02", Cod_Acceso == "*" ? "" : Cod_Acceso, Nombre_Acceso == "*" ? "" : Nombre_Acceso, Descripcion == "*" ? "" : Descripcion).Tables[0];
            {
                IList<CAcceso> list = new List<CAcceso>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getTAcceso(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }
        public virtual IList<CAccesoMenuP> BuscarAcceso(int IDPerfil, String Cod_Sistema)
        {
            Cod_Sistema = string.IsNullOrWhiteSpace(Cod_Sistema) ? "*" : Cod_Sistema;
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q04", Cod_Sistema == "*" ? "" : Cod_Sistema, IDPerfil).Tables[0];
            {
                IList<CAccesoMenuP> list = new List<CAccesoMenuP>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getTAccesoMenu(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }
        public virtual IList<CAcceso> Menu(int IDPerfil)
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_Acceso_Q03", IDPerfil ).Tables[0];
            {
                IList<CAcceso> list = new List<CAcceso>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getTAcceso(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }
        public virtual IList<CAcceso> AccesoNivelCero()
        {
            DataTable dtDatos = Db.ExecuteDataSet("TS_TAcceso_Q05").Tables[0];
            {
                IList<CAcceso> list = new List<CAcceso>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getTAcceso(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }
        #endregion
    }
}
