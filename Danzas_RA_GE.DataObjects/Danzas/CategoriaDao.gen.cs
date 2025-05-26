using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Danzas
{
    
    
    public partial class CategoriaDao : DataAccessBase
    {
        
        public virtual CCategoria getCategoria(DataRow dr)
        {
            return new CCategoria(Convert.ToString(dr["CategoriaID"]),Convert.ToString(dr["Nombre"]),Convert.ToString(dr["Descripcion"]));
        }
        
        public virtual CCategoria getCategoria(IDataReader dr)
        {
            return new CCategoria(Convert.ToString(dr["CategoriaID"]),Convert.ToString(dr["Nombre"]),Convert.ToString(dr["Descripcion"]));
        }
        
        #region Metodos Principales
        public virtual bool Grabar(CCategoria oCategoria)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("SP_Categoria_Guardar")){
            Db.AddInParameter(dbCmd, "CategoriaID", DbType.String, oCategoria.CategoriaID);
            Db.AddInParameter(dbCmd, "Nombre", DbType.String, oCategoria.Nombre);
            Db.AddInParameter(dbCmd, "Descripcion", DbType.String, oCategoria.Descripcion);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(String CategoriaID)
        {
            return Db.ExecuteNonQuery(".Categoria_Eliminar",CategoriaID);
        }
        
        public virtual CCategoria Recuperar(String CategoriaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Categoria_Recuperar", CategoriaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getCategoria(dtDatos.Rows[0]);
            else
            return new CCategoria();
        }
        
        public virtual bool Existe(String CategoriaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Categoria_Recuperar", CategoriaID).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(String CategoriaID, out CCategoria oCategoria)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Categoria_Recuperar", CategoriaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oCategoria = getCategoria(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oCategoria = new CCategoria();
            return false;
            }
        }
        
        public virtual IList<CCategoria> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader(CommandType.StoredProcedure, "SP_Categoria_Listar")){
            IList<CCategoria> list = new List<CCategoria>();
            while (dr.Read())
            list.Add(getCategoria(dr));
            return list;
            }
        }
        #endregion
    }
}
