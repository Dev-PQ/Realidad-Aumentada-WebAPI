using LibreriaNetCore.InfoApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace Danzas_RA_GE.DataObjects
{
    public class DataAccessBase
    {
        #region Atributos
        public Database Db;

        #endregion

        public DataAccessBase()
        {
            ProcesarConexion("Conexion");
            Db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(stringConexion);
        }
        private static string? TipoAplicacion = System.Configuration.ConfigurationManager.AppSettings.Get("TipoAplicacion");
        public static string varConexionWindows = "";
        private static IConfiguration? _configuration;
        static string? Conexion;
        public static string stringConexion
        {
            get
            {
                return _configuration.GetConnectionString(Conexion);
            }
        }

        public static void ProcesarConexion(string NameConnection)
        {
            Conexion = NameConnection;
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            _configuration = configurationBuilder.Build();
        }

        public static AplicacionBS.TipoApp Tipo_Aplicacion
        {
            get
            {
                if (TipoAplicacion != null)
                {
                    if (TipoAplicacion.ToUpper() == "WEB")
                        return AplicacionBS.TipoApp.Web;
                    else if (TipoAplicacion.ToUpper() == "WINDOWS")
                        return AplicacionBS.TipoApp.Windows;
                    else
                        return AplicacionBS.TipoApp.Windows;
                }
                else
                    return AplicacionBS.TipoApp.Web;
            }
        }

        public static string getVarConexion()
        {
            if (Tipo_Aplicacion == AplicacionBS.TipoApp.Web)
            {
                return "Conexion";
            }
            else
            {
                return varConexionWindows;
            }
        }
    }
}
