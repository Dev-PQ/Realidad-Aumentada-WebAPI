using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Configuracion;
using System.Security.Cryptography.X509Certificates;
using Danzas_RA_GE.BusinessObjects.Seguridad;

namespace Danzas_RA_GE.DataObjects
{
    
    
    public partial class ConfiguracionesSistemaDao : DataAccessBase
    {
        
        public virtual ConfiguracionesSistema getconfiguracionesSistema(DataRow dr)
        {
            return new ConfiguracionesSistema(
                dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                dr["Clave"] != DBNull.Value ? Convert.ToString(dr["Clave"]) : string.Empty,
                dr["Valor"] != DBNull.Value ? Convert.ToString(dr["Valor"]) : string.Empty,
                dr["Descripcion"] != DBNull.Value ? Convert.ToString(dr["Descripcion"]) : string.Empty,
                dr["FechaCreacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaCreacion"]) : DateTime.MinValue,
                dr["FechaModificacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaModificacion"]) : DateTime.MinValue
            );
        }
        
        public virtual ConfiguracionesSistema getconfiguracionesSistema(IDataReader dr)
        {
            return new ConfiguracionesSistema(
                dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                dr["Clave"] != DBNull.Value ? Convert.ToString(dr["Clave"]) : string.Empty,
                dr["Valor"] != DBNull.Value ? Convert.ToString(dr["Valor"]) : string.Empty,
                dr["Descripcion"] != DBNull.Value ? Convert.ToString(dr["Descripcion"]) : string.Empty,
                dr["FechaCreacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaCreacion"]) : DateTime.MinValue,
                dr["FechaModificacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaModificacion"]) : DateTime.MinValue
            );
        }
        
        #region Metodos Principales
        public virtual bool Grabar(ConfiguracionesSistema oconfiguracionesSistema)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("SP_ConfiguracionesSistema_Guardar")){
            Db.AddInParameter(dbCmd, "Id", DbType.Int32, oconfiguracionesSistema.Id);
            Db.AddInParameter(dbCmd, "Clave", DbType.String, oconfiguracionesSistema.Clave);
            Db.AddInParameter(dbCmd, "Valor", DbType.String, oconfiguracionesSistema.Valor);
            Db.AddInParameter(dbCmd, "Descripcion", DbType.String, oconfiguracionesSistema.Descripcion);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(Int32 Id)
        {
            return Db.ExecuteNonQuery("SP_ConfiguracionesSistema_Eliminar",Id);
        }
        
        public virtual ConfiguracionesSistema Recuperar(Int32 Id)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_ConfiguracionesSistema_Recuperar",Id).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getconfiguracionesSistema(dtDatos.Rows[0]);
            else
            return new ConfiguracionesSistema();
        }
        
        public virtual bool Existe(Int32 Id)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_ConfiguracionesSistema_Recuperar",Id).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(Int32 Id, out ConfiguracionesSistema oconfiguracionesSistema)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_ConfiguracionesSistema_Recuperar",Id).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oconfiguracionesSistema = getconfiguracionesSistema(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oconfiguracionesSistema = new ConfiguracionesSistema();
            return false;
            }
        }
        
        public virtual IList<ConfiguracionesSistema> Listar(Int32 ID, String Clave, String Valor, String Descripcion)
        {
            Clave = string.IsNullOrWhiteSpace(Clave) ? "*" : Clave;
            Valor = string.IsNullOrWhiteSpace(Valor) ? "*" : Valor;
            Descripcion = string.IsNullOrWhiteSpace(Descripcion) ? "*" : Descripcion;
            DataTable dtDatos = Db.ExecuteDataSet("SP_ConfiguracionesSistema_Listar", ID ,Clave,Valor, Descripcion).Tables[0];
            {
                IList<ConfiguracionesSistema> list = new List<ConfiguracionesSistema>();
                if (dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        list.Add(getconfiguracionesSistema(dtDatos.Rows[i]));
                    }
                }
                return list;
            }
        }

        public virtual int UltimoID()
        {
            using (IDataReader dr = Db.ExecuteReader(CommandType.StoredProcedure, "SP_ConfiguracionesSistema_UltimoID"))
            {
                if (dr.Read())
                {
                    return Convert.ToInt32(dr["IDActual"]);
                }
                else
                {
                    return 0; 
                }
            }
        }
        #endregion
    }
}
