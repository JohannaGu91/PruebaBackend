using MySql.Data.MySqlClient;
using System.Data;

namespace ApiModAdmin.Data.Conexion
{
    public class ConMySql
    {
        private MySqlConnection laConexion;
        public MySqlCommand Comando { get; set; }

        private Base conexion = new Base();

        public ConMySql()
        {
            laConexion = conexion.GetConexion();
            Comando = new MySqlCommand();
        }

        public void abrirConexion()
        {
            if (laConexion.State != ConnectionState.Open)
                laConexion.Open();
        }

        public void cerrarConexion()
        {
            if (laConexion.State != ConnectionState.Closed)
                laConexion.Close();
        }

        public MySqlDataReader ejecutaReader()
        {

            MySqlDataReader retValue;
            abrirConexion();
            Comando.Connection = laConexion;
            retValue = Comando.ExecuteReader(CommandBehavior.CloseConnection);

            return retValue;
        }

        public int ejecutaQuery()
        {
            int retValue;

            try
            {
                abrirConexion();
                Comando.Connection = laConexion;
                retValue = Comando.ExecuteNonQuery();
                cerrarConexion();
            }
            catch (MySqlException)
            {
                retValue = -1;
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return retValue;
        }

        public void Dispose()
        {
            cerrarConexion();
            laConexion = null;
        }
    }
}
