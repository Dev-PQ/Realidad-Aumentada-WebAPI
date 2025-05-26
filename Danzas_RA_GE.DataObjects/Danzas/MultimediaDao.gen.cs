using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Danzas
{
    
    
    public partial class MultimediaDao : DataAccessBase
    {
        
        public virtual CMultimedia getMultimedia(DataRow dr)
        {
            return new CMultimedia(Convert.ToInt32(dr["MultimediaID"]),Convert.ToString(dr["DanzaID"]),Convert.ToString(dr["Tipo"]),Convert.ToString(dr["URL"]),Convert.ToBoolean(dr["BinArchivoDanza"]),Convert.ToString(dr["Descripcion"]));
        }
        
        public virtual CMultimedia getMultimedia(IDataReader dr)
        {
            return new CMultimedia(Convert.ToInt32(dr["MultimediaID"]),Convert.ToString(dr["DanzaID"]),Convert.ToString(dr["Tipo"]),Convert.ToString(dr["URL"]),Convert.ToBoolean(dr["BinArchivoDanza"]),Convert.ToString(dr["Descripcion"]));
        }
        
        #region Metodos Principales
        public virtual bool Grabar(CMultimedia oMultimedia)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("SP_Multimedia_Guardar")){
            Db.AddInParameter(dbCmd, "MultimediaID", DbType.Int32, oMultimedia.MultimediaID);
            Db.AddInParameter(dbCmd, "DanzaID", DbType.String, oMultimedia.DanzaID);
            Db.AddInParameter(dbCmd, "Tipo", DbType.String, oMultimedia.Tipo);
            Db.AddInParameter(dbCmd, "URL", DbType.String, oMultimedia.URL);
            Db.AddInParameter(dbCmd, "BinArchivoDanza", DbType.Boolean, oMultimedia.BinArchivoDanza);
            Db.AddInParameter(dbCmd, "Descripcion", DbType.String, oMultimedia.Descripcion);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(Int32 MultimediaID)
        {
            return Db.ExecuteNonQuery(".Multimedia_Eliminar",MultimediaID);
        }
        
        public virtual CMultimedia Recuperar(Int32 MultimediaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Multimedia_Recuperar", MultimediaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getMultimedia(dtDatos.Rows[0]);
            else
            return new CMultimedia();
        }
        
        public virtual bool Existe(Int32 MultimediaID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Multimedia_Recuperar", MultimediaID).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(Int32 MultimediaID, out CMultimedia oMultimedia)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Multimedia_Recuperar", MultimediaID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oMultimedia = getMultimedia(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oMultimedia = new CMultimedia();
            return false;
            }
        }
        
        public virtual IList<CMultimedia> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader(CommandType.StoredProcedure, "SP_Multimedia_Listar")){
            IList<CMultimedia> list = new List<CMultimedia>();
            while (dr.Read())
            list.Add(getMultimedia(dr));
            return list;
            }
        }
        #endregion
    }
}
