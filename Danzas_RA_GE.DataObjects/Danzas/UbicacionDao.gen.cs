using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Danzas_RA_GE.BusinessObjects.Danzas;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Danzas_RA_GE.DataObjects.Danzas
{
    
    
    public partial class UbicacionDao : DataAccessBase
    {
        
        public virtual CUbicacion getUbicacion(DataRow dr)
        {
            return new CUbicacion(Convert.ToString(dr["UbicacionID"]),Convert.ToString(dr["DanzaID"]),Convert.ToDecimal(dr["Latitud"]),Convert.ToDecimal(dr["Longitud"]),Convert.ToString(dr["Direccion"]));
        }
        
        public virtual CUbicacion getUbicacion(IDataReader dr)
        {
            return new CUbicacion(Convert.ToString(dr["UbicacionID"]),Convert.ToString(dr["DanzaID"]),Convert.ToDecimal(dr["Latitud"]),Convert.ToDecimal(dr["Longitud"]),Convert.ToString(dr["Direccion"]));
        }
        
        #region Metodos Principales
        public virtual bool Grabar(CUbicacion oUbicacion)
        {
            using (DbCommand dbCmd = Db.GetStoredProcCommand("SP_Ubicacion_Guardar")){
            Db.AddInParameter(dbCmd, "UbicacionID", DbType.String, oUbicacion.UbicacionID);
            Db.AddInParameter(dbCmd, "DanzaID", DbType.String, oUbicacion.DanzaID);
            Db.AddInParameter(dbCmd, "Latitud", DbType.Decimal, oUbicacion.Latitud);
            Db.AddInParameter(dbCmd, "Longitud", DbType.Decimal, oUbicacion.Longitud);
            Db.AddInParameter(dbCmd, "Direccion", DbType.String, oUbicacion.Direccion);
            // --- Ejecutando procedimiento almacenado
            return Db.ExecuteNonQuery(dbCmd) > 0;
            } 
        }
        
        public virtual int Eliminar(String UbicacionID)
        {
            return Db.ExecuteNonQuery(".Ubicacion_Eliminar",UbicacionID);
        }
        
        public virtual CUbicacion Recuperar(String UbicacionID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Ubicacion_Recuperar", UbicacionID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            return getUbicacion(dtDatos.Rows[0]);
            else
            return new CUbicacion();
        }
        
        public virtual bool Existe(String UbicacionID)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Ubicacion_Recuperar", UbicacionID).Tables[0];
            return dtDatos.Rows.Count > 0;
        }
        
        public virtual bool Existe(String UbicacionID, out CUbicacion oUbicacion)
        {
            DataTable dtDatos = Db.ExecuteDataSet("SP_Ubicacion_Recuperar", UbicacionID).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
            oUbicacion = getUbicacion(dtDatos.Rows[0]);
            return true;
             }
            else
            {
            oUbicacion = new CUbicacion();
            return false;
            }
        }
        
        public virtual IList<CUbicacion> Listar()
        {
            using (IDataReader dr = Db.ExecuteReader(CommandType.StoredProcedure, "SP_Ubicacion_Listar")){
            IList<CUbicacion> list = new List<CUbicacion>();
            while (dr.Read())
            list.Add(getUbicacion(dr));
            return list;
            }
        }
        #endregion
    }
}
