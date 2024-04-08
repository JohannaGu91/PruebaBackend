using ApiModAmin.Providers;
using log4net;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace ApiModAdmin.Data.Conexion
{
    public class Base
    {
        public MySqlConnection GetConexion()
        {
            string sql = "";

            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

                IConfigurationRoot configuration = builder.Build();
                sql = configuration.GetConnectionString("conexionSQL");

                return new MySqlConnection(sql);
            }
            catch
            {
                throw;
            }
        }
    }
}
