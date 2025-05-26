using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Danzas
{
    
    
    public partial class DanzaDao : DataAccessBase
    {
        
        public virtual CDanza getDanza(DataRow dr)
        {
            return new CDanza(Convert.ToString(dr["DanzaID"]),Convert.ToString(dr["Nombre"]),Convert.ToString(dr["Descripcion"]),Convert.ToString(dr["Historia"]),Convert.ToString(dr["CategoriaID"]));
        }
        
        public virtual CDanza getDanza(IDataReader dr)
        {
            return new CDanza(Convert.ToString(dr["DanzaID"]),Convert.ToString(dr["Nombre"]),Convert.ToString(dr["Descripcion"]),Convert.ToString(dr["Historia"]),Convert.ToString(dr["CategoriaID"]));
        }
        
        #region Metodos Principales
        public virtual bool Grabar(CDanza oDanza)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("SP_Danza_Guardar")){
            Db.AddInParameter(dbCmd, "DanzaID", DbType.String, oDanza.DanzaID);
            Db.AddInParameter(dbCmd, "Nombre", DbType.String, oDanza.Nombre);
            Db.AddInParameter(dbCmd, "Descripcion", DbType.String, oDanza.Descripcion);
            Db.AddInParameter(dbCmd, "Historia", DbType.String, oDanza.Historia);
            Db.AddInParameter(dbCmd, "CategoriaID", DbType.String, oDanza.CategoriaID);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(String DanzaID)
        {
            return Db.ExecuteNonQuery(".Danza_Eliminar",DanzaID);
        }
        
        public virtual CDanza Recuperar(String DanzaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Danza_Recuperar", DanzaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getDanza(dtDatos.Rows[0]);
            else
            return new CDanza();
        }
        
        public virtual bool Existe(String DanzaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Danza_Recuperar", DanzaID).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(String DanzaID, out CDanza oDanza)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Danza_Recuperar", DanzaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oDanza = getDanza(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oDanza = new CDanza();
            return false;
            }
        }
        
        public virtual IList<CDanza> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader(CommandType.StoredProcedure, "SP_Danza_Listar")){
            IList<CDanza> list = new List<CDanza>();
            while (dr.Read())
            list.Add(getDanza(dr));
            return list;
            }
        }
        #endregion
    }
}
